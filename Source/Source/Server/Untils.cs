using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Security.Principal;

namespace Server
{
    public static class Untils
    {
        // Mouse event constants
        public const uint MOUSEEVENTF_ABSOLUTE = 0x8000;
        public const uint MOUSEEVENTF_LEFTDOWN = 0x0002;
        public const uint MOUSEEVENTF_LEFTUP = 0x0004;
        public const uint MOUSEEVENTF_MIDDLEDOWN = 0x0020;
        public const uint MOUSEEVENTF_MIDDLEUP = 0x0040;
        public const uint MOUSEEVENTF_MOVE = 0x0001;
        public const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;
        public const uint MOUSEEVENTF_RIGHTUP = 0x0010;
        public const uint MOUSEEVENTF_XDOWN = 0x0080;
        public const uint MOUSEEVENTF_XUP = 0x0100;
        public const uint MOUSEEVENTF_WHEEL = 0x0800;
        public const uint MOUSEEVENTF_HWHEEL = 0x01000;

        // Keyboard event constants
        public const int KEYEVENTF_EXTENDEKEY = 1;
        public const int KEYEVENTF_KEYUP = 2;

        // Virtual key codes
        public const int virtualKeyControl = 17;
        public const int virtualKeyEscape = 27;

        // External function declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(long dwFlags, long dx, long dy, long cButtons, long dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern uint keyboard_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        public static bool IsMetro(Bitmap screen)
        {
            // Check if the screen is in metro mode
            Color color1 = screen.GetPixel(6, 6);
            Color color2 = screen.GetPixel(screen.Width - 6, 6);

            if (color1.ToArgb() != color2.ToArgb())
                return false;

            Color color3 = screen.GetPixel(6, screen.Height - 30);
            Color color4 = screen.GetPixel(screen.Width - 6, screen.Height - 30);

            if (color2.ToArgb() == color3.ToArgb() && color3.ToArgb() == color4.ToArgb())
                return true;

            return false;
        }

        public static void SyncKeys(string command)
        {
            // Synchronize keyboard locks based on the received command
            string[] Items = command.ToLower().Split(' ');

            if (Control.IsKeyLocked(Keys.CapsLock).ToString().ToLower() != Items[1])
                Untils.CapsLock();

            if (Control.IsKeyLocked(Keys.NumLock).ToString().ToLower() != Items[2])
                Untils.NumLock();
        }

        public static void ShowTaskmanager()
        {
            try
            {
                // Open the task manager
                System.Diagnostics.Process.Start(@"C:\Windows\system32\taskmgr.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ShowMetro()
        {
            // Show the metro right sidebar menu
            Untils.keyboard_event((byte)Keys.LWin, 0, Untils.KEYEVENTF_EXTENDEKEY, 0);
            Untils.keyboard_event((byte)Keys.C, 0, Untils.KEYEVENTF_EXTENDEKEY, 0);
            Untils.keyboard_event((byte)Keys.LWin, 0, Untils.KEYEVENTF_EXTENDEKEY | Untils.KEYEVENTF_KEYUP, 0);
            Untils.keyboard_event((byte)Keys.C, 0, Untils.KEYEVENTF_EXTENDEKEY | Untils.KEYEVENTF_KEYUP, 0);
            Cursor.Position = new Point(Screen.PrimaryScreen.Bounds.Width - 30, Screen.PrimaryScreen.Bounds.Height / 2);
            Thread.Sleep(20);
        }

        public static void ShowStart()
        {
            // Show the Windows start button
            Untils.keyboard_event((byte)Keys.LWin, 0, Untils.KEYEVENTF_EXTENDEKEY, 0);
            Untils.keyboard_event((byte)Keys.LWin, 0, Untils.KEYEVENTF_EXTENDEKEY | Untils.KEYEVENTF_KEYUP, 0);
        }

        public static void CapsLock()
        {
            // Toggle the Caps Lock
            Untils.keyboard_event(0x14, 0x45, Untils.KEYEVENTF_EXTENDEKEY, 0);
            Untils.keyboard_event(0x14, 0x45, Untils.KEYEVENTF_EXTENDEKEY | Untils.KEYEVENTF_KEYUP, 0);
        }

        public static void NumLock()
        {
            // Toggle the Num Lock
            Untils.keyboard_event(0x90, 0x45, Untils.KEYEVENTF_EXTENDEKEY, 0);
            Untils.keyboard_event(0x90, 0x45, Untils.KEYEVENTF_EXTENDEKEY | Untils.KEYEVENTF_KEYUP, 0);
        }

        public static void ScrollHorizontal(int Amount)
        {
            // Scroll horizontally
            Untils.mouse_event(Untils.MOUSEEVENTF_HWHEEL, 0, 0, Amount, 0);
        }

        public static void ScrollVertical(int Amount)
        {
            // Scroll vertically
            Untils.mouse_event(Untils.MOUSEEVENTF_HWHEEL, 0, 0, Amount, 0);
        }

        public static string XorString(string Value, int Shift, bool Outbound)
        {
            // XOR encrypt/decrypt the string with the given shift value
            if (Outbound)
                Value = Value.Replace(" ", "#SS#");

            string Output = string.Empty;
            int character = 0;

            for (int f = 0; f <= Value.Length - 1; f++)
            {
                character = Convert.ToInt32(Value[f]);

                if (Outbound && character == 113)
                    character = Convert.ToInt32('¬');
                else if (!Outbound && character == 172)
                    character = 113;
                else
                    character ^= Shift;

                Output += char.ConvertFromUtf32(character);
            }

            if (!Outbound)
                return Output.Replace("#SS#", " ");
            else
                return Output;
        }

        public static bool IsUserAdministrator()
        {
            // Check if the user running the server has administrator rights
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}
