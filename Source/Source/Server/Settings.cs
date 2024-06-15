using System.Windows.Forms;
using Microsoft.Win32;

namespace Server
{
    public class Settings
    {
        // Settings variables
        public static bool FirstTime = true;
        public static string MainProgramName = "Server RD";
        public static string Password = "secret";
        public static Menu FormService = null;
        public static int Port = 4000;
        public static bool Debug = false;
        public static int ScreenServerX = 1920;
        public static int ScreenServerY = 1080;

        // Load settings from registry
        public static void LoadSettings()
        {
            // Parse the "FirstTime" setting from registry
            Settings.FirstTime = bool.Parse(LoadSetting("FirstTime", "true"));

            // Set the screen size based on the primary screen's bounds
            Settings.ScreenServerX = Screen.PrimaryScreen.Bounds.Width + 5;
            Settings.ScreenServerY = Screen.PrimaryScreen.Bounds.Height + 5;

            // Parse the "Port" setting from registry
            Settings.Port = int.Parse(LoadSetting("Port", "4000"));

            // Load the "Password" setting from registry
            Settings.Password = LoadSetting("id", "secret");

            // Parse the "ScreenServerX" and "ScreenServerY" settings from registry
            Settings.ScreenServerX = int.Parse(LoadSetting("ScreenServerX", Settings.ScreenServerX.ToString()));
            Settings.ScreenServerY = int.Parse(LoadSetting("ScreenServerY", Settings.ScreenServerY.ToString()));
        }

        // Save settings to the registry
        public static void SaveSettings()
        {
            // Save the "ScreenServerX" and "ScreenServerY" settings to registry
            SaveSetting("ScreenServerX", Settings.ScreenServerX.ToString());
            SaveSetting("ScreenServerY", Settings.ScreenServerY.ToString());

            // Save the "Port" and "Password" settings to registry
            SaveSetting("Port", Settings.Port.ToString());
            SaveSetting("id", Settings.Password);

            // Save the "FirstTime" setting to registry
            SaveSetting("FirstTime", Settings.FirstTime.ToString());
        }

        // Save a setting to the registry
        public static void SaveSetting(string Name, string Value)
        {
            try
            {
                // Create or open the registry subkey for the main program
                RegistryKey Root = Registry.CurrentUser.CreateSubKey(MainProgramName);

                // Set the value of the specified setting
                Root.SetValue(Name, Value);
            }
            catch
            {
                // Ignore any errors that occur while saving the setting
            }
        }

        // Load a setting from the registry
        public static string LoadSetting(string Name, string Default)
        {
            try
            {
                // Create or open the registry subkey for the main program
                RegistryKey Root = Registry.CurrentUser.CreateSubKey(MainProgramName);

                // Get the value of the specified setting
                return Root.GetValue(Name)?.ToString() ?? Default;
            }
            catch
            {
                // Save the default value to registry if an error occurs while loading the setting
                SaveSetting(Name, Default);

                // Return the default value
                return Default;
            }
        }
    }
}
