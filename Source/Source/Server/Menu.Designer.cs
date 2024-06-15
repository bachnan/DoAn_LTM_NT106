namespace Server
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.buttonClear = new System.Windows.Forms.Button();
            this.textDebug = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonCancelSettings = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonFirewall = new System.Windows.Forms.Button();
            this.ImageBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(459, 12);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 28);
            this.buttonClear.TabIndex = 0;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            this.buttonClear.MouseHover += new System.EventHandler(this.buttonClear_MouseHover);
            // 
            // textDebug
            // 
            this.textDebug.Location = new System.Drawing.Point(0, -2);
            this.textDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textDebug.Multiline = true;
            this.textDebug.Name = "textDebug";
            this.textDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textDebug.Size = new System.Drawing.Size(431, 422);
            this.textDebug.TabIndex = 1;
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(459, 58);
            this.buttonHide.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(75, 30);
            this.buttonHide.TabIndex = 2;
            this.buttonHide.Text = "Hide";
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(459, 106);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(75, 30);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(208, 9);
            this.portBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(108, 22);
            this.portBox.TabIndex = 4;
            this.portBox.Text = "4000";
            this.portBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "TCP port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(208, 54);
            this.passwordBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(108, 22);
            this.passwordBox.TabIndex = 6;
            this.passwordBox.Text = "letmein";
            this.passwordBox.Visible = false;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(31, 124);
            this.buttonSaveSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(139, 32);
            this.buttonSaveSettings.TabIndex = 8;
            this.buttonSaveSettings.Text = "Save Settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Visible = false;
            this.buttonSaveSettings.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonSaveSettings_MouseClick);
            // 
            // buttonCancelSettings
            // 
            this.buttonCancelSettings.Location = new System.Drawing.Point(185, 124);
            this.buttonCancelSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancelSettings.Name = "buttonCancelSettings";
            this.buttonCancelSettings.Size = new System.Drawing.Size(132, 32);
            this.buttonCancelSettings.TabIndex = 9;
            this.buttonCancelSettings.Text = "Cancel";
            this.buttonCancelSettings.UseVisualStyleBackColor = true;
            this.buttonCancelSettings.Visible = false;
            this.buttonCancelSettings.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonCancelSettings_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(364, 64);
            this.label3.TabIndex = 10;
            this.label3.Text = "This is the remote desktop program using TCP/IP \r\nso it needs firewall rule to al" +
    "low/forward this port for machine. \r\n\r\nPassword is important for making connecti" +
    "on secure.";
            // 
            // buttonFirewall
            // 
            this.buttonFirewall.Location = new System.Drawing.Point(29, 350);
            this.buttonFirewall.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFirewall.Name = "buttonFirewall";
            this.buttonFirewall.Size = new System.Drawing.Size(141, 30);
            this.buttonFirewall.TabIndex = 14;
            this.buttonFirewall.Text = "Add new firewall rule";
            this.buttonFirewall.UseVisualStyleBackColor = true;
            this.buttonFirewall.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonFirewall_MouseClick);
            // 
            // ImageBackground
            // 
            this.ImageBackground.Image = global::Server.Properties.Resources.Background1;
            this.ImageBackground.Location = new System.Drawing.Point(445, 215);
            this.ImageBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ImageBackground.Name = "ImageBackground";
            this.ImageBackground.Size = new System.Drawing.Size(89, 126);
            this.ImageBackground.TabIndex = 12;
            this.ImageBackground.TabStop = false;
            this.ImageBackground.Visible = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 420);
            this.Controls.Add(this.ImageBackground);
            this.Controls.Add(this.textDebug);
            this.Controls.Add(this.buttonCancelSettings);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonFirewall);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Menu";
            this.Text = "Server RD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Menu_FormClosing);
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textDebug;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonCancelSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox ImageBackground;
        private System.Windows.Forms.Button buttonFirewall;
    }
}

