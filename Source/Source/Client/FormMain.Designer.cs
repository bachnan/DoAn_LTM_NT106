namespace Client
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.TaskBar = new System.Windows.Forms.GroupBox();
            this.buttonView = new System.Windows.Forms.PictureBox();
            this.buttonMinimize = new System.Windows.Forms.PictureBox();
            this.buttonRestore = new System.Windows.Forms.PictureBox();
            this.buttonClose = new System.Windows.Forms.PictureBox();
            this.LableTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.TrackWidth = new System.Windows.Forms.HScrollBar();
            this.TrackHeight = new System.Windows.Forms.VScrollBar();
            this.checkLeftMenu = new System.Windows.Forms.CheckBox();
            this.buttonShutDown = new System.Windows.Forms.Button();
            this.buttonDisconect = new System.Windows.Forms.Button();
            this.TrackSpeed = new System.Windows.Forms.TrackBar();
            this.buttonMetro = new System.Windows.Forms.Button();
            this.buttonSendCtrlAltDel = new System.Windows.Forms.Button();
            this.buttonSendStart = new System.Windows.Forms.Button();
            this.checkEncrypted = new System.Windows.Forms.CheckBox();
            this.checkSendKeyboardAndMouse = new System.Windows.Forms.CheckBox();
            this.checkDebug = new System.Windows.Forms.CheckBox();
            this.checkResoloution = new System.Windows.Forms.CheckBox();
            this.checkScale = new System.Windows.Forms.CheckBox();
            this.checkLeftMenuConnect = new System.Windows.Forms.CheckBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.checkBlackWallpaper = new System.Windows.Forms.CheckBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.textIPAddress = new System.Windows.Forms.TextBox();
            this.buttonMenuSmall = new System.Windows.Forms.Button();
            this.GroupConected = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.GroupConnect = new System.Windows.Forms.GroupBox();
            this.buttonFirewall = new System.Windows.Forms.Button();
            this.imageDefaultBackground = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.theImage = new System.Windows.Forms.PictureBox();
            this.TaskBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRestore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSpeed)).BeginInit();
            this.GroupConected.SuspendLayout();
            this.GroupConnect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageDefaultBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.theImage)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskBar
            // 
            this.TaskBar.BackColor = System.Drawing.Color.SlateGray;
            this.TaskBar.Controls.Add(this.buttonView);
            this.TaskBar.Controls.Add(this.buttonMinimize);
            this.TaskBar.Controls.Add(this.buttonRestore);
            this.TaskBar.Controls.Add(this.buttonClose);
            this.TaskBar.Controls.Add(this.LableTitle);
            this.TaskBar.Location = new System.Drawing.Point(43, 0);
            this.TaskBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TaskBar.Name = "TaskBar";
            this.TaskBar.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TaskBar.Size = new System.Drawing.Size(379, 38);
            this.TaskBar.TabIndex = 1;
            this.TaskBar.TabStop = false;
            this.TaskBar.Visible = false;
            this.TaskBar.MouseHover += new System.EventHandler(this.TaskBar_MouseHover);
            // 
            // buttonView
            // 
            this.buttonView.Image = global::Client.Properties.Resources.View;
            this.buttonView.Location = new System.Drawing.Point(5, 12);
            this.buttonView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(31, 20);
            this.buttonView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonView.TabIndex = 52;
            this.buttonView.TabStop = false;
            this.buttonView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonMenu_MouseClick);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.Image = global::Client.Properties.Resources.Minimize;
            this.buttonMinimize.Location = new System.Drawing.Point(269, 10);
            this.buttonMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(31, 20);
            this.buttonMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonMinimize.TabIndex = 51;
            this.buttonMinimize.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonMinimize, "Minimize window");
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            this.buttonMinimize.MouseHover += new System.EventHandler(this.buttonMinimize_MouseHover);
            // 
            // buttonRestore
            // 
            this.buttonRestore.Image = global::Client.Properties.Resources.Restore;
            this.buttonRestore.Location = new System.Drawing.Point(305, 10);
            this.buttonRestore.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRestore.Name = "buttonRestore";
            this.buttonRestore.Size = new System.Drawing.Size(31, 20);
            this.buttonRestore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonRestore.TabIndex = 50;
            this.buttonRestore.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonRestore, "Restore window");
            this.buttonRestore.Click += new System.EventHandler(this.buttonRestore_Click);
            this.buttonRestore.MouseHover += new System.EventHandler(this.buttonRestore_MouseHover);
            // 
            // buttonClose
            // 
            this.buttonClose.Image = global::Client.Properties.Resources.Close;
            this.buttonClose.Location = new System.Drawing.Point(341, 10);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(31, 20);
            this.buttonClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.buttonClose.TabIndex = 49;
            this.buttonClose.TabStop = false;
            this.toolTip1.SetToolTip(this.buttonClose, "Close window");
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            this.buttonClose.MouseHover += new System.EventHandler(this.buttonClose_MouseHover);
            // 
            // LableTitle
            // 
            this.LableTitle.AutoSize = true;
            this.LableTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LableTitle.ForeColor = System.Drawing.Color.White;
            this.LableTitle.Location = new System.Drawing.Point(78, 14);
            this.LableTitle.Name = "LableTitle";
            this.LableTitle.Size = new System.Drawing.Size(103, 16);
            this.LableTitle.TabIndex = 1;
            this.LableTitle.Text = "127.0.0.1:4000";
            // 
            // TrackWidth
            // 
            this.TrackWidth.Location = new System.Drawing.Point(55, 231);
            this.TrackWidth.Maximum = 2570;
            this.TrackWidth.Minimum = 800;
            this.TrackWidth.Name = "TrackWidth";
            this.TrackWidth.Size = new System.Drawing.Size(285, 21);
            this.TrackWidth.TabIndex = 57;
            this.toolTip1.SetToolTip(this.TrackWidth, "Desktop width");
            this.TrackWidth.Value = 800;
            this.TrackWidth.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TrackWidth_Scroll);
            // 
            // TrackHeight
            // 
            this.TrackHeight.Location = new System.Drawing.Point(29, 58);
            this.TrackHeight.Maximum = 2000;
            this.TrackHeight.Minimum = 600;
            this.TrackHeight.Name = "TrackHeight";
            this.TrackHeight.Size = new System.Drawing.Size(21, 196);
            this.TrackHeight.TabIndex = 56;
            this.toolTip1.SetToolTip(this.TrackHeight, "Desktop Height");
            this.TrackHeight.Value = 690;
            this.TrackHeight.Scroll += new System.Windows.Forms.ScrollEventHandler(this.TrackHeight_Scroll);
            // 
            // checkLeftMenu
            // 
            this.checkLeftMenu.AutoSize = true;
            this.checkLeftMenu.BackColor = System.Drawing.Color.Transparent;
            this.checkLeftMenu.Location = new System.Drawing.Point(79, 116);
            this.checkLeftMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkLeftMenu.Name = "checkLeftMenu";
            this.checkLeftMenu.Size = new System.Drawing.Size(82, 20);
            this.checkLeftMenu.TabIndex = 54;
            this.checkLeftMenu.Text = "Left View";
            this.toolTip1.SetToolTip(this.checkLeftMenu, "Move View to the left");
            this.checkLeftMenu.UseVisualStyleBackColor = false;
            this.checkLeftMenu.CheckedChanged += new System.EventHandler(this.checkLeftMenu_CheckedChanged);
            // 
            // buttonShutDown
            // 
            this.buttonShutDown.Location = new System.Drawing.Point(248, 260);
            this.buttonShutDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonShutDown.Name = "buttonShutDown";
            this.buttonShutDown.Size = new System.Drawing.Size(92, 33);
            this.buttonShutDown.TabIndex = 48;
            this.buttonShutDown.Text = "Shut down";
            this.toolTip1.SetToolTip(this.buttonShutDown, "Shut down remote server");
            this.buttonShutDown.UseVisualStyleBackColor = true;
            this.buttonShutDown.Click += new System.EventHandler(this.buttonShutDown_Click);
            // 
            // buttonDisconect
            // 
            this.buttonDisconect.Location = new System.Drawing.Point(55, 260);
            this.buttonDisconect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDisconect.Name = "buttonDisconect";
            this.buttonDisconect.Size = new System.Drawing.Size(96, 33);
            this.buttonDisconect.TabIndex = 46;
            this.buttonDisconect.Text = "Disconect";
            this.toolTip1.SetToolTip(this.buttonDisconect, "Disconnect desktop");
            this.buttonDisconect.UseVisualStyleBackColor = true;
            this.buttonDisconect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonDisconect_MouseClick);
            // 
            // TrackSpeed
            // 
            this.TrackSpeed.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.TrackSpeed.Location = new System.Drawing.Point(81, 160);
            this.TrackSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrackSpeed.Maximum = 10000;
            this.TrackSpeed.Minimum = 2;
            this.TrackSpeed.Name = "TrackSpeed";
            this.TrackSpeed.Size = new System.Drawing.Size(141, 56);
            this.TrackSpeed.TabIndex = 47;
            this.toolTip1.SetToolTip(this.TrackSpeed, "Refresh Speed");
            this.TrackSpeed.Value = 2000;
            this.TrackSpeed.Scroll += new System.EventHandler(this.TrackSpeed_Scroll);
            // 
            // buttonMetro
            // 
            this.buttonMetro.Location = new System.Drawing.Point(245, 22);
            this.buttonMetro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMetro.Name = "buttonMetro";
            this.buttonMetro.Size = new System.Drawing.Size(92, 30);
            this.buttonMetro.TabIndex = 51;
            this.buttonMetro.Text = "Metro";
            this.toolTip1.SetToolTip(this.buttonMetro, "Show Metro View button on remote machine");
            this.buttonMetro.UseVisualStyleBackColor = true;
            this.buttonMetro.Click += new System.EventHandler(this.buttonMetro_Click);
            // 
            // buttonSendCtrlAltDel
            // 
            this.buttonSendCtrlAltDel.Location = new System.Drawing.Point(155, 22);
            this.buttonSendCtrlAltDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendCtrlAltDel.Name = "buttonSendCtrlAltDel";
            this.buttonSendCtrlAltDel.Size = new System.Drawing.Size(85, 30);
            this.buttonSendCtrlAltDel.TabIndex = 50;
            this.buttonSendCtrlAltDel.Text = "Restart";
            this.toolTip1.SetToolTip(this.buttonSendCtrlAltDel, "Show task-manger button on remote machine");
            this.buttonSendCtrlAltDel.UseVisualStyleBackColor = true;
            this.buttonSendCtrlAltDel.Click += new System.EventHandler(this.buttonSendCtrlAltDel_Click);
            // 
            // buttonSendStart
            // 
            this.buttonSendStart.Location = new System.Drawing.Point(53, 22);
            this.buttonSendStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSendStart.Name = "buttonSendStart";
            this.buttonSendStart.Size = new System.Drawing.Size(96, 30);
            this.buttonSendStart.TabIndex = 49;
            this.buttonSendStart.Text = "Start";
            this.toolTip1.SetToolTip(this.buttonSendStart, "Press start button on remote machine");
            this.buttonSendStart.UseVisualStyleBackColor = true;
            this.buttonSendStart.Click += new System.EventHandler(this.buttonSendStart_Click);
            // 
            // checkEncrypted
            // 
            this.checkEncrypted.AutoSize = true;
            this.checkEncrypted.BackColor = System.Drawing.Color.Transparent;
            this.checkEncrypted.Location = new System.Drawing.Point(212, 116);
            this.checkEncrypted.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkEncrypted.Name = "checkEncrypted";
            this.checkEncrypted.Size = new System.Drawing.Size(90, 20);
            this.checkEncrypted.TabIndex = 45;
            this.checkEncrypted.Text = "Encrypted";
            this.toolTip1.SetToolTip(this.checkEncrypted, "Encrypt remote desktop connection");
            this.checkEncrypted.UseVisualStyleBackColor = false;
            this.checkEncrypted.CheckedChanged += new System.EventHandler(this.checkEncrypted_CheckedChanged);
            // 
            // checkSendKeyboardAndMouse
            // 
            this.checkSendKeyboardAndMouse.AutoSize = true;
            this.checkSendKeyboardAndMouse.BackColor = System.Drawing.Color.Transparent;
            this.checkSendKeyboardAndMouse.Checked = true;
            this.checkSendKeyboardAndMouse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSendKeyboardAndMouse.Location = new System.Drawing.Point(212, 62);
            this.checkSendKeyboardAndMouse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkSendKeyboardAndMouse.Name = "checkSendKeyboardAndMouse";
            this.checkSendKeyboardAndMouse.Size = new System.Drawing.Size(133, 20);
            this.checkSendKeyboardAndMouse.TabIndex = 41;
            this.checkSendKeyboardAndMouse.Text = "Control Keyboard";
            this.toolTip1.SetToolTip(this.checkSendKeyboardAndMouse, "Control the remote desktop");
            this.checkSendKeyboardAndMouse.UseVisualStyleBackColor = false;
            this.checkSendKeyboardAndMouse.CheckedChanged += new System.EventHandler(this.checkSendKeyboardAndMouse_CheckedChanged);
            // 
            // checkDebug
            // 
            this.checkDebug.AutoSize = true;
            this.checkDebug.BackColor = System.Drawing.Color.Transparent;
            this.checkDebug.Location = new System.Drawing.Point(79, 62);
            this.checkDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkDebug.Name = "checkDebug";
            this.checkDebug.Size = new System.Drawing.Size(70, 20);
            this.checkDebug.TabIndex = 40;
            this.checkDebug.Text = "Debug";
            this.toolTip1.SetToolTip(this.checkDebug, "SShow debug on remote desktop");
            this.checkDebug.UseVisualStyleBackColor = false;
            this.checkDebug.CheckedChanged += new System.EventHandler(this.checkDebug_CheckedChanged);
            // 
            // checkResoloution
            // 
            this.checkResoloution.AutoSize = true;
            this.checkResoloution.BackColor = System.Drawing.Color.Transparent;
            this.checkResoloution.Location = new System.Drawing.Point(212, 89);
            this.checkResoloution.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkResoloution.Name = "checkResoloution";
            this.checkResoloution.Size = new System.Drawing.Size(122, 20);
            this.checkResoloution.TabIndex = 39;
            this.checkResoloution.Text = "32-bit resolution";
            this.toolTip1.SetToolTip(this.checkResoloution, "Show 32bit desktop");
            this.checkResoloution.UseVisualStyleBackColor = false;
            this.checkResoloution.CheckedChanged += new System.EventHandler(this.checkResoloution_CheckedChanged);
            // 
            // checkScale
            // 
            this.checkScale.AutoSize = true;
            this.checkScale.BackColor = System.Drawing.Color.Transparent;
            this.checkScale.Location = new System.Drawing.Point(79, 89);
            this.checkScale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkScale.Name = "checkScale";
            this.checkScale.Size = new System.Drawing.Size(127, 20);
            this.checkScale.TabIndex = 38;
            this.checkScale.Text = "Compress scale";
            this.toolTip1.SetToolTip(this.checkScale, "Compress data to speed up");
            this.checkScale.UseVisualStyleBackColor = false;
            this.checkScale.CheckedChanged += new System.EventHandler(this.checkScale_CheckedChanged);
            // 
            // checkLeftMenuConnect
            // 
            this.checkLeftMenuConnect.AutoSize = true;
            this.checkLeftMenuConnect.BackColor = System.Drawing.Color.Transparent;
            this.checkLeftMenuConnect.Location = new System.Drawing.Point(44, 132);
            this.checkLeftMenuConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkLeftMenuConnect.Name = "checkLeftMenuConnect";
            this.checkLeftMenuConnect.Size = new System.Drawing.Size(82, 20);
            this.checkLeftMenuConnect.TabIndex = 57;
            this.checkLeftMenuConnect.Text = "Left View";
            this.toolTip1.SetToolTip(this.checkLeftMenuConnect, "Scale the remote desktop image down");
            this.checkLeftMenuConnect.UseVisualStyleBackColor = false;
            this.checkLeftMenuConnect.CheckedChanged += new System.EventHandler(this.checkLeftMenuConnect_CheckedChanged);
            // 
            // textPassword
            // 
            this.textPassword.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPassword.ForeColor = System.Drawing.Color.Black;
            this.textPassword.Location = new System.Drawing.Point(149, 90);
            this.textPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textPassword.Name = "textPassword";
            this.textPassword.Size = new System.Drawing.Size(173, 27);
            this.textPassword.TabIndex = 48;
            this.textPassword.Text = "letmein";
            this.toolTip1.SetToolTip(this.textPassword, "Remote desktop IP-Address");
            this.textPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPassword_KeyDown);
            // 
            // buttonConnect
            // 
            this.buttonConnect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonConnect.Location = new System.Drawing.Point(36, 178);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(96, 30);
            this.buttonConnect.TabIndex = 46;
            this.buttonConnect.Text = "Connect";
            this.toolTip1.SetToolTip(this.buttonConnect, "Connect to the remote desktop");
            this.buttonConnect.UseVisualStyleBackColor = false;
            this.buttonConnect.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonConnect_MouseClick);
            // 
            // checkBlackWallpaper
            // 
            this.checkBlackWallpaper.AutoSize = true;
            this.checkBlackWallpaper.BackColor = System.Drawing.Color.Transparent;
            this.checkBlackWallpaper.Checked = true;
            this.checkBlackWallpaper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBlackWallpaper.Location = new System.Drawing.Point(149, 132);
            this.checkBlackWallpaper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBlackWallpaper.Name = "checkBlackWallpaper";
            this.checkBlackWallpaper.Size = new System.Drawing.Size(129, 20);
            this.checkBlackWallpaper.TabIndex = 45;
            this.checkBlackWallpaper.Text = "Black Wallpaper";
            this.toolTip1.SetToolTip(this.checkBlackWallpaper, "Use black remote desktop");
            this.checkBlackWallpaper.UseVisualStyleBackColor = false;
            this.checkBlackWallpaper.CheckedChanged += new System.EventHandler(this.checkBlackWallpaper_CheckedChanged_1);
            // 
            // textPort
            // 
            this.textPort.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textPort.ForeColor = System.Drawing.Color.Black;
            this.textPort.Location = new System.Drawing.Point(149, 55);
            this.textPort.Margin = new System.Windows.Forms.Padding(4);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(173, 27);
            this.textPort.TabIndex = 7;
            this.textPort.Text = "4000";
            this.toolTip1.SetToolTip(this.textPort, "Remote desktop port");
            this.textPort.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textPort_KeyDown);
            // 
            // textIPAddress
            // 
            this.textIPAddress.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textIPAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textIPAddress.ForeColor = System.Drawing.Color.Black;
            this.textIPAddress.Location = new System.Drawing.Point(149, 25);
            this.textIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.textIPAddress.Name = "textIPAddress";
            this.textIPAddress.Size = new System.Drawing.Size(173, 27);
            this.textIPAddress.TabIndex = 6;
            this.textIPAddress.Text = "10.10.10.25";
            this.toolTip1.SetToolTip(this.textIPAddress, "Remote desktop IP-Address");
            this.textIPAddress.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textIPAddress_KeyDown);
            // 
            // buttonMenuSmall
            // 
            this.buttonMenuSmall.BackgroundImage = global::Client.Properties.Resources.View;
            this.buttonMenuSmall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuSmall.Location = new System.Drawing.Point(5, 6);
            this.buttonMenuSmall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMenuSmall.Name = "buttonMenuSmall";
            this.buttonMenuSmall.Size = new System.Drawing.Size(32, 26);
            this.buttonMenuSmall.TabIndex = 53;
            this.toolTip1.SetToolTip(this.buttonMenuSmall, "Show/Hide View");
            this.buttonMenuSmall.UseVisualStyleBackColor = true;
            this.buttonMenuSmall.Visible = false;
            this.buttonMenuSmall.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonMenuSmall_MouseDown);
            this.buttonMenuSmall.MouseHover += new System.EventHandler(this.buttonMenuSmall_MouseHover);
            // 
            // GroupConected
            // 
            this.GroupConected.BackColor = System.Drawing.Color.WhiteSmoke;
            this.GroupConected.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupConected.Controls.Add(this.label6);
            this.GroupConected.Controls.Add(this.TrackWidth);
            this.GroupConected.Controls.Add(this.TrackHeight);
            this.GroupConected.Controls.Add(this.checkLeftMenu);
            this.GroupConected.Controls.Add(this.buttonShutDown);
            this.GroupConected.Controls.Add(this.buttonDisconect);
            this.GroupConected.Controls.Add(this.label4);
            this.GroupConected.Controls.Add(this.label5);
            this.GroupConected.Controls.Add(this.TrackSpeed);
            this.GroupConected.Controls.Add(this.buttonMetro);
            this.GroupConected.Controls.Add(this.buttonSendCtrlAltDel);
            this.GroupConected.Controls.Add(this.buttonSendStart);
            this.GroupConected.Controls.Add(this.checkEncrypted);
            this.GroupConected.Controls.Add(this.checkSendKeyboardAndMouse);
            this.GroupConected.Controls.Add(this.checkDebug);
            this.GroupConected.Controls.Add(this.checkResoloution);
            this.GroupConected.Controls.Add(this.checkScale);
            this.GroupConected.Location = new System.Drawing.Point(43, 43);
            this.GroupConected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupConected.Name = "GroupConected";
            this.GroupConected.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupConected.Size = new System.Drawing.Size(379, 314);
            this.GroupConected.TabIndex = 2;
            this.GroupConected.TabStop = false;
            this.GroupConected.Visible = false;
            this.GroupConected.MouseHover += new System.EventHandler(this.GroupConected_MouseHover);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(76, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 23);
            this.label6.TabIndex = 58;
            this.label6.Text = "       Refresh Speed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(77, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 16);
            this.label4.TabIndex = 52;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(204, 140);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 16);
            this.label5.TabIndex = 53;
            this.label5.Text = "+";
            // 
            // GroupConnect
            // 
            this.GroupConnect.BackColor = System.Drawing.Color.Gainsboro;
            this.GroupConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupConnect.Controls.Add(this.checkLeftMenuConnect);
            this.GroupConnect.Controls.Add(this.buttonFirewall);
            this.GroupConnect.Controls.Add(this.imageDefaultBackground);
            this.GroupConnect.Controls.Add(this.textPassword);
            this.GroupConnect.Controls.Add(this.label3);
            this.GroupConnect.Controls.Add(this.buttonConnect);
            this.GroupConnect.Controls.Add(this.checkBlackWallpaper);
            this.GroupConnect.Controls.Add(this.textPort);
            this.GroupConnect.Controls.Add(this.textIPAddress);
            this.GroupConnect.Controls.Add(this.label2);
            this.GroupConnect.Controls.Add(this.label1);
            this.GroupConnect.Location = new System.Drawing.Point(37, 242);
            this.GroupConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupConnect.Name = "GroupConnect";
            this.GroupConnect.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GroupConnect.Size = new System.Drawing.Size(379, 231);
            this.GroupConnect.TabIndex = 3;
            this.GroupConnect.TabStop = false;
            // 
            // buttonFirewall
            // 
            this.buttonFirewall.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonFirewall.Location = new System.Drawing.Point(235, 178);
            this.buttonFirewall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFirewall.Name = "buttonFirewall";
            this.buttonFirewall.Size = new System.Drawing.Size(96, 30);
            this.buttonFirewall.TabIndex = 56;
            this.buttonFirewall.Text = "Firewall";
            this.buttonFirewall.UseVisualStyleBackColor = false;
            this.buttonFirewall.Click += new System.EventHandler(this.buttonFirewall_Click);
            // 
            // imageDefaultBackground
            // 
            this.imageDefaultBackground.Location = new System.Drawing.Point(329, 27);
            this.imageDefaultBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageDefaultBackground.Name = "imageDefaultBackground";
            this.imageDefaultBackground.Size = new System.Drawing.Size(29, 126);
            this.imageDefaultBackground.TabIndex = 55;
            this.imageDefaultBackground.TabStop = false;
            this.imageDefaultBackground.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 47;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(83, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP Address:";
            // 
            // theImage
            // 
            this.theImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.theImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.theImage.Location = new System.Drawing.Point(0, 0);
            this.theImage.Margin = new System.Windows.Forms.Padding(0);
            this.theImage.Name = "theImage";
            this.theImage.Size = new System.Drawing.Size(453, 501);
            this.theImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.theImage.TabIndex = 54;
            this.theImage.TabStop = false;
            this.theImage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.theImage_MouseClick);
            this.theImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.theImage_MouseDown);
            this.theImage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.theImage_MouseMove);
            this.theImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.theImage_MouseUp);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 501);
            this.Controls.Add(this.GroupConected);
            this.Controls.Add(this.GroupConnect);
            this.Controls.Add(this.TaskBar);
            this.Controls.Add(this.buttonMenuSmall);
            this.Controls.Add(this.theImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.Text = "Client RD";
            this.Activated += new System.EventHandler(this.FormMain_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.TaskBar.ResumeLayout(false);
            this.TaskBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonRestore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrackSpeed)).EndInit();
            this.GroupConected.ResumeLayout(false);
            this.GroupConected.PerformLayout();
            this.GroupConnect.ResumeLayout(false);
            this.GroupConnect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageDefaultBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.theImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox TaskBar;
        private System.Windows.Forms.Label LableTitle;
        private System.Windows.Forms.GroupBox GroupConected;
        private System.Windows.Forms.CheckBox checkEncrypted;
        private System.Windows.Forms.CheckBox checkSendKeyboardAndMouse;
        private System.Windows.Forms.CheckBox checkDebug;
        private System.Windows.Forms.CheckBox checkResoloution;
        private System.Windows.Forms.CheckBox checkScale;
        private System.Windows.Forms.GroupBox GroupConnect;
        private System.Windows.Forms.Button buttonDisconect;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.CheckBox checkBlackWallpaper;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.TextBox textIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TrackSpeed;
        private System.Windows.Forms.Button buttonShutDown;
        private System.Windows.Forms.PictureBox buttonClose;
        private System.Windows.Forms.PictureBox buttonRestore;
        private System.Windows.Forms.PictureBox buttonMinimize;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonMenuSmall;
        private System.Windows.Forms.Button buttonSendCtrlAltDel;
        private System.Windows.Forms.Button buttonSendStart;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMetro;
        private System.Windows.Forms.PictureBox imageDefaultBackground;
        private System.Windows.Forms.Button buttonFirewall;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox theImage;
        private System.Windows.Forms.CheckBox checkLeftMenu;
        private System.Windows.Forms.CheckBox checkLeftMenuConnect;
        private System.Windows.Forms.PictureBox buttonView;
        private System.Windows.Forms.VScrollBar TrackHeight;
        private System.Windows.Forms.HScrollBar TrackWidth;
        private System.Windows.Forms.Label label6;
    }
}