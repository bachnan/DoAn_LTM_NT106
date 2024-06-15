using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Media;
using System.Net;


namespace Server
{
    public class ServerHandler
    {
        #region Static members used for our main listen service
        public static Image ImageBackground = null;// Set custom wallpaper
        private static bool Closing = false;        // Shut down without any error messages 
        private static TcpListener listener = null; // Used to listen for any new client connections, maximium is 3 at the same time
        public static ServerHandler Service1 = null;       // Servers for 3 client connection, only one used most the time
        private static ServerHandler Service2 = null;
        private static ServerHandler Service3 = null;
        private static Thread ThreadListen = null;      // One and only main thread used to wait for new connections
        private static bool FirstConnect = true;       
        private static void ShowDebug(bool Debug)
        {
            Settings.Debug = Debug;
            if (Settings.FormService == null || Closing) return;
            if (Debug)
            {
                Settings.FormService.Invoke((MethodInvoker)delegate()
                {
                    // This code runs on the forms thread
                    Settings.FormService.Show();
                    Settings.FormService.BringToFront();
                    Settings.FormService.Focus();
                });
            }
            else
                Settings.FormService.Invoke((MethodInvoker)delegate()
                {
                   Settings.FormService.Hide();
                });
        }

        public static void ListenStart()
        {
            Closing = false;
            ThreadListen = new Thread(new ThreadStart(Listen));
            ThreadListen.Start();
        }

        public static void ListenStop(bool CloseState)
        {
           // Stop listening connection
           Closing = CloseState;
           Thread thread = new Thread(new ThreadStart(ListenStopNow));
           thread.Start();
        }

        private static void ListenStopNow()
        {
            //Shut down any services and the listener 
            Wallpaper.RestoreWallpaper();
            bool CloseState = Closing;
            Closing = true;
            if (listener != null)
            {
                listener.Server.Close();
                listener.Stop();
            }
            if (Service1 != null && Service1.Running) Service1.Stop();
            if (Service2 != null && Service2.Running) Service2.Stop();
            if (Service3 != null && Service3.Running) Service3.Stop();

            if (ThreadListen != null)
            {
                ThreadListen.Abort();
            }
            if (CloseState) Environment.Exit(0);
        }

        public static bool IsClientsConnected()
        {
            if (Service1 != null && Service1.Running) return true;
            if (Service2 != null && Service1.Running) return true;
            if (Service3 != null && Service1.Running) return true;
            return false;
        }

        private static void Listen()
        {
            // Waiting for new conections to come in and can deal with a maximium of 3 clients at the same time
            Socket socket = null;
            PrintDebug("Start listen with port " + Settings.Port.ToString(), true);
            try
            {
                listener = new TcpListener(IPAddress.Any, Settings.Port); 
                listener.Start();

                while (ThreadListen != null)
                {
                    socket = listener.AcceptSocket();
                    PrintDebug("Connect " + socket.RemoteEndPoint.ToString(), true);
                    string message = Settings.ScreenServerX + " " + Settings.ScreenServerY + " " + Screen.PrimaryScreen.Bounds.Width + " " + Screen.PrimaryScreen.Bounds.Height + " " + FirstConnect.ToString();
                    FirstConnect = false;
                    byte[] Bmessage = ASCIIEncoding.ASCII.GetBytes(message);
                    socket.Send(Bmessage, Bmessage.Length, SocketFlags.None);
                    // Use to handle multiple clients
                    if (Service1 == null || !Service1.Running) { 
                        Service1 = new ServerHandler(); 
                        Service1.Start(Settings.Port, socket, Settings.ScreenServerX, Settings.ScreenServerY); 
                    }
                    else if (Service2 == null || !Service2.Running) { 
                        Service2 = new ServerHandler(); 
                        Service2.Start(Settings.Port, socket, Settings.ScreenServerX, Settings.ScreenServerY); 
                    }
                    else if (Service3 == null || !Service3.Running) { 
                        Service3 = new ServerHandler(); 
                        Service3.Start(Settings.Port, socket, Settings.ScreenServerX, Settings.ScreenServerY); 
                    }
                }
                listener.Stop();
            }
            catch (Exception ex)
            {
                PrintDebug("Error listen " + ex.Message, true);
            }
        }

        private static void PrintDebug(string message, bool Force)
        {
            if (Closing) return;
            if ((Settings.Debug || Force) && Settings.FormService != null)
            {
                Settings.FormService.Invoke((MethodInvoker)delegate()
                {
                    //This code runs on the forms thread
                   Settings.FormService.PrintDebug(message, Force);
                });
            }
        }
        #endregion  // Start instance used to process upto 3 conection at the same time 

        private int ScreenClientX = 1920;           // Sizes of the client and server screen
        private int ScreenClientY = 1080;
        private int ScreenServerX = 1920;
        private int ScreenServerY = 1080;
        private bool Encrypted = false;             // Flag for encryption on the screen, keyboard text always uses simple XOR encryption
        private bool Sleep = false;                 
        private int Padding = 3;
        private bool IsMetro = false;               // Flag for windows metro mode to nudge pen type devices to scroll the edge of the sceen 
        public int imageDelay = 2000;
        private Socket ServerSocket;                // Socket used for connection
        private int Port;                           // Port to listen on
        private Stream CStream;
        private Thread threadEvents = null;             // Used to listen for commands coming in
        private Thread threadServer = null;             // Used to push the destop image to the client
        public bool Running = false;
        private bool LoggedIn = false;
        private int SleepCount = 0;
        private bool Scale = false;                 // Set if scaling the size of the desktop image down to save bandwidth
        private bool Lock = false;                  // Set if the client close for a while
        private bool HadEvent = false;              // Set true if event sent from client
        private PixelFormat ImageResoloution = PixelFormat.Format16bppRgb555;// PixelFormat.Format32bppArgb;
        private DateTime LastEventTime = DateTime.Now;       // Stop talking to the service and it will close itself to save the CPU
        private string LastClipboardText = string.Empty;
        private Brush BrushWait = Brushes.Yellow;

        public void Start(int port,Socket serverSocket,int ScreenX,int screen)
        {
           // Start new threads to send the desktop image and another to wait for keyboard/mouse commands to come in
           this.Scale = false;
           this.imageDelay = 2000;
           this.Sleep = false;
           this.ScreenServerX = ScreenX;
           this.ScreenServerY = screen;
           this.ScreenClientX = Screen.PrimaryScreen.Bounds.Width; 
           this.ScreenClientY = Screen.PrimaryScreen.Bounds.Height; 
           this.ImageResoloution = PixelFormat.Format16bppRgb555;   // This resolution allow 16-bit and 32-bit
           this.Running = true;
           this.LoggedIn = false; 
           this.SleepCount = 0;
           this.ServerSocket = serverSocket;
           Settings.Port = port;
           this.Port = port;
           this.CStream = new NetworkStream(ServerSocket);
           LastClipboardText = ClipboardAsync.GetText();
           threadEvents = new Thread(new ThreadStart(WaitForCommands));
           threadEvents.Start();
           Thread.Sleep(300);  // Give the command thread a chance to start
           threadServer = new Thread(new ThreadStart(PushTheDesktopToClients));
           threadServer.Start();
        }

        public void Stop()
        {
            Wallpaper.RestoreWallpaper();
            this.Running = false;
            Thread.Sleep(200);// Try to let things close down for the threads
            if (ServerSocket.IsBound) ServerSocket.Close();
            this.CStream = null;
            if (this.threadEvents!=null) this.threadEvents.Abort();
            if (this.threadServer !=null) this.threadServer.Abort();
        }

        public void SleepDelay()
        {
            // Sleep a bit so the network and the local CPU does not get over worked
            for (int i=0; i<=this.imageDelay/100; i++)
            {
                Thread.Sleep(100);
                if (HadEvent)// The client sent a mouse move or something so wake up and send the desktop back a bit early
                {
                    HadEvent = false;
                    return;
                }   
            }
        }

        private Bitmap ResizeImage(Bitmap originalBitmap, int width, int height)
        {
            Bitmap resizedBitmap = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(resizedBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalBitmap, 0, 0, width, height);
            }

            return resizedBitmap;
        }

        private void SendScreenInfo(string data)
        {
            // The screen sizes need sending to the client
            string modifiedData = "#INFO#" + data;
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(Untils.XorString(modifiedData.Replace(Environment.NewLine, "#NL#").Replace("\n", "#NL#").Replace("'", "#SQ#"), 34, true));

            if (this.Encrypted)
            {
                // Easy if a memory stream was always used and serialized but it comes at the price of performance, it all takes time
                using (MemoryStream ms = new MemoryStream(dataBytes))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(CStream, ms);
                }

                PrintDebug("INFO << Length=" + (modifiedData.Length - 6), true);
            }
            else
            {
                // When sent like this the client will catch an error and inform this service to lock, fixes the error and then tells this service to unlock
                Lock = true; // Client will send unlock message
                CStream.Write(dataBytes, 0, dataBytes.Length);
                CStream.Flush();
                PrintDebug("INFO << Length=" + (modifiedData.Length - 6), true);
            }
        }


        public void SendClipboard()
        {
            string text = ClipboardAsync.GetText();
            if (text == null || text == LastClipboardText)
                return;

            LastClipboardText = text;

            if (this.Encrypted && LastClipboardText.Length > 0)
            {
                string modifiedText = "#CLIPBOARD#" + LastClipboardText;
                byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(Untils.XorString(modifiedText, 34, true));

                using (MemoryStream ms = new MemoryStream(dataBytes))
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(CStream, ms);
                }

                PrintDebug("CLIPBOARD << Length=" + text.Length, true);
            }
            else if (LastClipboardText.Length > 0)
            {
                string modifiedText = "#CLIPBOARD#" + LastClipboardText.Replace(Environment.NewLine, "#NL#").Replace("\n", "#NL#").Replace("'", "#SQ#");
                byte[] dataBytes = UTF8Encoding.UTF8.GetBytes("                                  " + Untils.XorString(modifiedText, 34, true));

                Lock = true; // Client will send unlock message
                CStream.Write(dataBytes, 0, dataBytes.Length);
                CStream.Flush();
                PrintDebug("CLIPBOARD << Length=" + text.Length, true);
            }
        }

        public static MemoryStream Encrypt(Bitmap image)
        {
            // Generate a seed byte array
            byte[] seed = { (byte)DateTime.Now.Millisecond, (byte)DateTime.Now.Hour, (byte)DateTime.Now.Second, 97, 113, 102 }; // Example values: [millisecond, hour, second, 'a', 'q', 'f']

            // Create a new MemoryStream and directly save the image into it
            using (MemoryStream msIn = new MemoryStream())
            {
                image.Save(msIn, ImageFormat.Png);

                // Write the seed byte array at the beginning of the stream
                msIn.Position = 0;
                msIn.Write(seed, 0, seed.Length);

                // Return the MemoryStream without disposing the original bitmap
                return msIn;
            }
        }

        private void KeepMachineAwake()
        {
            // Fake key-move to keep the machine awake
            LastEventTime = DateTime.Now;
            SendKeys.SendWait("{DOWN}");
            Thread.Sleep(50);
            SendKeys.SendWait("{UP}");
        }

        private void PushTheDesktopToClients()
        {
            string Stage = "Start";
            try
            {
                while (this.Running)
                {
                    TimeSpan TS = DateTime.Now - LastEventTime;
                    if (TS.TotalMinutes  > 10) KeepMachineAwake();
                    if (!this.Sleep && this.LoggedIn)
                    {
                        BinaryFormatter bFormat = new BinaryFormatter();
                        try
                        {
                            if (this.ScreenClientX != Screen.PrimaryScreen.Bounds.Width || this.ScreenClientY != Screen.PrimaryScreen.Bounds.Height) WriteScreenSize();
                            this.SleepCount = 0;
                            SendClipboard();
                            Bitmap screen = new Bitmap(this.ScreenServerX + this.Padding, this.ScreenServerY + this.Padding, this.ImageResoloution);
                            Graphics screenShot = Graphics.FromImage(screen);
                            Stage = "Got Screen";
                            System.Drawing.Size Sz = new System.Drawing.Size(this.ScreenServerX + this.Padding, this.ScreenServerY + this.Padding);
                            screenShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, this.Padding, this.Padding, Sz, CopyPixelOperation.SourceCopy);
                            this.IsMetro = Untils.IsMetro(screen);
                            if (this.Scale) 
                                screen = ResizeImage(screen, this.ScreenServerX / 2, this.ScreenServerY / 2);
                            Stage = "Copy Screen";
                            int X = 0; int Y = 0;
                            Color CursorColor = WindowsCursor.CaptureCursor(ref X, ref Y, screenShot, this.ScreenServerX, this.ScreenServerY);
                            screen.SetPixel(0, 0, CursorColor);
                            if (this.IsMetro)
                                screen.SetPixel(0, 1, Color.Black);
                            else
                                screen.SetPixel(0, 1, Color.Red);
                            if (!Lock)
                            {
                                if (this.Encrypted)
                                {
                                    MemoryStream MS = Encrypt(screen);
                                    bFormat.Serialize(CStream, MS);
                                }
                                else
                                {
                                    bFormat.Serialize(CStream, screen);
                                }
                            }
                            Stage = "Serialize Screen";
                            SleepDelay();
                            screenShot.Dispose();
                            screen.Dispose();
                        }
                        catch (Exception ex1)
                        {
                            if (!this.Running) return;
                            if (ex1.Message.StartsWith("Unable to write data to the transport connection") || !this.ServerSocket.Connected)
                            {
                                this.threadServer = null;
                                this.Stop();
                                return;
                            }
                            else if (ex1.Message.StartsWith("The handle is invalid"))
                            {
                                Bitmap screen = (Bitmap)ServerHandler.ImageBackground;
                                Graphics G = Graphics.FromImage(screen);
                                if (BrushWait == Brushes.Yellow) BrushWait = Brushes.Orange; else BrushWait = Brushes.Yellow;
                                G.FillEllipse(BrushWait, 170, 100, 60, 60);
                                screen.SetPixel(0, 0, Color.Fuchsia);
                                if (this.Encrypted)
                                {
                                    MemoryStream MS = Encrypt(screen);
                                    bFormat.Serialize(CStream, MS);
                                }
                                else
                                    bFormat.Serialize(CStream, screen);
                                Thread.Sleep(3000);
                            }
                            else
                                PrintDebug("Screen Error " + Stage + " " + ex1.Message, true);
                            Thread.Sleep(50); 
                        }
                    }
                    else
                    {
              
                        this.SleepCount++;
                        Thread.Sleep(500);
                        if (!this.LoggedIn && SleepCount>25) 
                        {
                            PrintDebug("NO LOGIN", true);
                            Stop();
                        }
                        else if (SleepCount > 7200) 
                        {
                            PrintDebug("Session timeout", true);
                            Stop();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PrintDebug("Error Stop " + ex.Message,true);
                Stop();
            }
        }

        private void TestPassword(string Password)
        {
            if (Password.Trim() == Settings.Password.ToLower() || Settings.Password.Length == 0)
                this.LoggedIn = true;
            else
            {
                PrintDebug("Bad password", true);
                this.Stop();
            }
        }
       
        private void ReadCommandValues(string temp)
        {
            //Could be a key-stroke or a mouse move/click to do something else
            if (temp.StartsWith("CDELAY"))
            {
               PrintDebug(temp,false);
               this.imageDelay = int.Parse(temp.Substring(6, temp.Length - 6));
            }
            else if (temp.StartsWith("CMD "))
            {
                bool Force = false;
                string command = temp.Substring(3).Trim();
                if (command == "OK") return;
                if (command.StartsWith("PASSWORD ")) { TestPassword(command.Substring(9).ToLower()); command = "PASSWORD *******"; Force = true; }
                if (command.StartsWith("KEYSYNC ")) Untils.SyncKeys(command); 
                if (command == "SUP" && this.IsMetro) Untils.ScrollVertical(-50);
                if (command == "SDOWN" && this.IsMetro) Untils.ScrollVertical(50);
                if (command == "SLEFT" && this.IsMetro) Untils.ScrollHorizontal(-50);
                if (command == "SRIGHT" && this.IsMetro) Untils.ScrollHorizontal(50);
                if (command == "SHOWSTART") Untils.ShowStart();

                if (command.StartsWith("PADDING ")) { this.Padding = int.Parse(command.Replace("PADDING ", string.Empty).Trim()); }
                if (command.StartsWith("DEBUG FALSE")) { PrintDebug(command, false); ShowDebug(false); }
                if (command.StartsWith("DEBUG TRUE")) { ShowDebug(true); Force = true; }
                if (command.StartsWith("ENCRYPTED TRUE")) this.Encrypted = true;
                if (command.StartsWith("ENCRYPTED FALSE")) this.Encrypted = false;
                if (command.StartsWith("SLEEP TRUE")) this.Sleep  = true;
                if (command.StartsWith("SLEEP FALSE")) this.Sleep = false;
                PrintDebug(command, Force);
                if (command.StartsWith("SCALE "))this.Scale = bool.Parse(command.ToLower().Replace("scale ", string.Empty));
                if (command.StartsWith("RESOLUTION TRUE")) this.ImageResoloution = PixelFormat.Format32bppArgb;
                if (command.StartsWith("RESOLUTION FALSE")) this.ImageResoloution = PixelFormat.Format16bppRgb555;
                if (command.StartsWith("WALLPAPER TRUE")) Wallpaper.SetWallpaper();
                if (command.StartsWith("WALLPAPER FALSE")) Wallpaper.RestoreWallpaper();
                if (command.StartsWith("METRO")) Untils.ShowMetro();
                if (command.StartsWith("CTRLALTDELETE")) Untils.ShowTaskmanager();
                if (command.StartsWith("CLOSE")) this.Stop();
            }
            else if (temp.StartsWith("CLIPBOARD "))
            {
                LastClipboardText = temp.Substring(10).Replace("#NL#", Environment.NewLine).Replace("#SQ#","'");
                PrintDebug("CLIPBOARD >> Length=" + LastClipboardText.Length , false);
                ClipboardAsync.SetText(LastClipboardText);
            }
            else if (temp.StartsWith("SCREEN "))
            {
                PrintDebug(temp, false);
                this.ScreenServerX = int.Parse(temp.Split(' ')[1]);
                this.ScreenServerY = int.Parse(temp.Split(' ')[2]);
                Settings.ScreenServerX = this.ScreenServerX;
                Settings.ScreenServerY = this.ScreenServerY;
            }
            else if (temp.StartsWith("UNLOCK"))
            {
                //Can send more data
                PrintDebug(temp, false);
                this.Lock = false;
            }
            else if (temp.StartsWith("LOCK"))
            {
                //Don't send more data
                PrintDebug(temp, false);
                this.Lock = true;
            }
            else if (temp.StartsWith("BEEP"))
            {
                PrintDebug(temp, false);
                SystemSounds.Asterisk.Play();
            }
            else if (temp.StartsWith("SHUTDOWN"))
            {
                PrintDebug(temp, false);
                ListenStop(true);
            }
            else if (temp.StartsWith("{CAPSLOCK}"))
            {
                Untils.CapsLock();
                return;
            }
            else if (temp.StartsWith("{NUMLOCK}"))
            {
                Untils.NumLock();
                return;
            }
            else if (temp.StartsWith("LDOWN"))
            {
                Untils.mouse_event(Untils.MOUSEEVENTF_LEFTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
            else if (temp.StartsWith("LUP"))
            {
                Untils.mouse_event(Untils.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
            else if (temp.StartsWith("RCLICK"))
            {
                Untils.mouse_event(Untils.MOUSEEVENTF_RIGHTDOWN | Untils.MOUSEEVENTF_LEFTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
            else if (temp.StartsWith("RDOWN"))
            {
                Untils.mouse_event(Untils.MOUSEEVENTF_RIGHTDOWN, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
            else if (temp.StartsWith("RUP"))
            {
                Untils.mouse_event(Untils.MOUSEEVENTF_RIGHTUP, Cursor.Position.X, Cursor.Position.Y, 0, 0);
            }
            else if (temp.StartsWith("M"))
            {
                int xPos = 0, yPos = 0;
                try
                {
                    xPos = int.Parse(temp.Substring(1, temp.IndexOf(' ')));
                    yPos = int.Parse(temp.Substring(temp.IndexOf(' '), temp.Length - temp.IndexOf(' ')));
                    Cursor.Position = new Point(xPos, yPos);
                }
                catch (Exception ex)
                {
                   PrintDebug("Error Mouse " + ex.Message, true);
                }
            }
            else
            {
                if (temp == "^c") PrintDebug("{COPY}", true);
                else if (temp == "^v") PrintDebug("{PASTE}", true);
                else if (temp.Length >1) PrintDebug(temp, true);
                SendKeys.SendWait(temp);
            }
        }

        private void WriteScreenSize()
        {
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;
            SendScreenInfo("SCREEN_" + screenWidth + "_" + screenHeight);
            this.ScreenClientX = screenWidth;
            this.ScreenClientY = screenHeight;
            this.ScreenServerX = screenWidth;
            this.ScreenServerY = screenHeight;
        }

        private void WaitForCommands()
        {
            // Runs on its own thread and wait for the client to send commands for the keyboard or mouse
            StreamReader reader = new StreamReader(CStream);
            while (this.Running && !Closing)
            {
                if (this.Sleep) Thread.Sleep(1000);
                try
                {
                    if (this.ScreenClientX != Screen.PrimaryScreen.Bounds.Width || this.ScreenClientY != Screen.PrimaryScreen.Bounds.Height) WriteScreenSize();
                    int Shift = 45;
                    string temp = reader.ReadLine();
                    if (temp.Length == 1)
                        Shift = 77; //Change encryption shift if it's just a keystroke to make it harder to listen in on the conversation
                    temp = Untils.XorString(temp, Shift, false);//Could use more heavey weight encryption here since the size is small
                    if (temp == "C33C") temp = " ";
                    LastEventTime = DateTime.Now;  //Stop talking to server for a long time then shut down the connection !
                    if (temp != null)
                    {
                        ReadCommandValues(temp); //Processs the command got
                        HadEvent = true;
                    }
                }
                catch (Exception ex)
                {
                    if (!this.ServerSocket.Connected && !Closing && this.Running)
                    {
                        PrintDebug("Error waitForKeys " + ex.Message, true);
                        this.threadEvents = null;
                        this.Stop();
                        return;
                    }
                }                
           }
       }
    }
}
