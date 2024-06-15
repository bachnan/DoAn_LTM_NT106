using System;
using System.Windows.Forms;

namespace Server
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        // Prints debug message if debug mode is enabled or force flag is true
        public void PrintDebug(string message, bool force)
        {
            if (Settings.Debug || force)
            {
                textDebug.Text = message + Environment.NewLine + textDebug.Text;

                // Limit the length of the debug text to 20000 characters
                if (textDebug.Text.Length > 20000)
                    textDebug.Text = textDebug.Text.Substring(10000);
            }
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Set the window title to the main program name
            this.Text = Settings.MainProgramName;

            // Check if Caps Lock is enabled
            bool isCapsLockEnabled = Control.IsKeyLocked(Keys.CapsLock);

            // Set the window state to Normal
            this.WindowState = FormWindowState.Normal;

            // Set the background image of the server
            ServerHandler.ImageBackground = ImageBackground.Image;

            // Save the wallpaper
            Wallpaper.SaveWallpaper();

            // Load the settings
            Settings.LoadSettings();

            // Set the form service to this instance
            Settings.FormService = this;

            // Check if the user is an administrator
            if (!Untils.IsUserAdministrator())
            {
                PrintDebug("This action requires administrator rights to allow control of windows system forms and settings." + Environment.NewLine, true);
            }

            if (Settings.FirstTime)
            {
                // Show settings and populate password and port fields
                ShowSettings(true);
                passwordBox.Text = Settings.Password;
                portBox.Text = Settings.Port.ToString();
            }
            else
            {
                // Start listening for connections
                ServerHandler.ListenStart();
            }
        }

        private void Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save the settings
            Settings.SaveSettings();

            // Stop listening for connections and close all clients
            ServerHandler.ListenStop(true);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // Clear the debug text
            textDebug.Text = string.Empty;
        }

        private void buttonClear_MouseHover(object sender, EventArgs e)
        {
            // Change the cursor to SizeAll when hovering over the Clear button
            Cursor.Current = Cursors.SizeAll;
        }

        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (ServerHandler.IsClientsConnected())
            {
                // Display a confirmation dialog before changing settings
                DialogResult answer = MessageBox.Show("Connection will be closed before any settings can be changed", "Change Settings", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (answer == DialogResult.Cancel)
                    return;
            }

            // Stop listening for connections
            ServerHandler.ListenStop(false);

            // Show the settings and populate password and port fields
            ShowSettings(true);
            passwordBox.Text = Settings.Password;
            portBox.Text = Settings.Port.ToString();
        }

        private void buttonCancelSettings_MouseDown(object sender, MouseEventArgs e)
        {
            // Hide the settings and start listening for connections
            ShowSettings(false);
            if (!Settings.FirstTime)
                ServerHandler.ListenStart();
            else
                PrintDebug("Service not started", true);
        }

        private void ShowSettings(bool isVisible)
        {
            if (Settings.FirstTime)
                buttonSaveSettings.Text = "Allow connections";
            else
                buttonSaveSettings.Text = "Save setting";

            // Show/hide the settings related controls
            buttonCancelSettings.Visible = isVisible;
            buttonSaveSettings.Visible = isVisible;
            buttonFirewall.Visible = isVisible;
            portBox.Visible = isVisible;
            passwordBox.Visible = isVisible;
            textDebug.Visible = !isVisible;
            buttonClear.Visible = !isVisible;
            buttonSettings.Visible = !isVisible;
            buttonHide.Visible = !isVisible;
        }

        private void buttonFirewall_MouseClick(object sender, MouseEventArgs e)
        {
            if (Untils.IsUserAdministrator())
            {
                // Set the program name for the Firewall rule
                Firewall.ProgramName = Settings.MainProgramName;

                if (Firewall.AllowThisProgram("TCP", Settings.Port.ToString(), string.Empty, "IN"))
                {
                    // Show success message and start listening for connections
                    MessageBox.Show("New firewall rule added for port " + Settings.Port, Settings.MainProgramName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowSettings(false);
                    ServerHandler.ListenStart();
                    return;
                }
            }

            // Show error message if program is not run as an administrator
            MessageBox.Show("This program requires administrator right to add new Firewall rules", Settings.MainProgramName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ShowSettings(false);
            ServerHandler.ListenStart();
        }

        private void buttonSaveSettings_MouseClick(object sender, MouseEventArgs e)
        {
            // Save the password and port settings
            Settings.Password = passwordBox.Text.Trim();

            try
            {
                Settings.Port = int.Parse(portBox.Text.Trim());
            }
            catch (Exception ex)
            {
                // Handle parsing error and show error message
                MessageBox.Show(ex.Message);
            }

            // Set the first time flag to false and save the settings
            Settings.FirstTime = false;
            Settings.SaveSettings();

            // Hide the settings and start listening for connections
            ShowSettings(false);
            ServerHandler.ListenStart();
            textDebug.Visible = true;
            PrintDebug("Settings saved", true);
            textDebug.Focus();
        }
    }
}
