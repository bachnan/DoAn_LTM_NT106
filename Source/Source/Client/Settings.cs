using System.Windows.Forms;
using Microsoft.Win32;

namespace Client
{
    public static class Settings
    {
        public static int Padding = 1;
        public static bool LeftMenu = false;
        public static string Password = "secret";
        public static bool Sleep = false;
        public static string IP = "127.0.0.1";
        public static int Port = 4000;
        public static string MainProgramName = "Client RD";
        public static bool Connected = false;
        public static int Speed = 2000; 
        public static bool Debug = false;
        public static bool Encrypted = true;
        public static bool IsMetro = false;
        public static int ScreenServerX = 1920;
        public static int ScreenServerY = 1080;
        public static int ScreenClientX = 1920;
        public static int ScreenClientY = 1080;
        public static bool Scale = false;
        public static bool BlackWallpaper = true;
        public static bool Resolution = true;
        public static bool SendKeysAndMouse = true;

        public static void SaveSettings()
        {
            SaveSetting("Speed", Settings.Speed.ToString());
            SaveSetting("Encrypted", Settings.Encrypted.ToString());
            SaveSetting("Debug", Settings.Debug.ToString());
            SaveSetting("ScreenServerX", Settings.ScreenServerX.ToString());
            SaveSetting("ScreenServerY", Settings.ScreenServerY.ToString());
            SaveSetting("Scale", Settings.Scale.ToString());
            SaveSetting("BlackWallpaper", Settings.BlackWallpaper.ToString());
            SaveSetting("Resolution", Settings.Resolution.ToString());
            SaveSetting("SendKeysAndMouse", Settings.SendKeysAndMouse.ToString());
            SaveSetting("LeftMenu", Settings.LeftMenu.ToString());
        }

        public static void SaveLogonDetails()
        {
            SaveSetting("IP", Settings.IP.ToString());
            SaveSetting("Port", Settings.Port.ToString());
            SaveSetting("ID", Settings.Password);
        }

        public static void LoadSettings()
        {
            Settings.ScreenServerX = Screen.PrimaryScreen.Bounds.Width + 5;
            Settings.ScreenServerY = Screen.PrimaryScreen.Bounds.Height + 5;
            Settings.Speed = int.Parse(LoadSetting("Speed", "2000"));
            Settings.ScreenServerX = int.Parse(LoadSetting("ScreenServerX", Settings.ScreenServerX.ToString()));
            Settings.ScreenServerY = int.Parse(LoadSetting("ScreenServerY", Settings.ScreenServerY.ToString()));
            Settings.Port = int.Parse(LoadSetting("Port", "4000"));
            Settings.Encrypted = bool.Parse(LoadSetting("Encrypted", "false"));
            Settings.Debug = bool.Parse(LoadSetting("Debug", "false"));
            Settings.Scale = bool.Parse(LoadSetting("Scale", "false"));
            Settings.BlackWallpaper = bool.Parse(LoadSetting("BlackWallpaper", "false"));
            Settings.Resolution = bool.Parse(LoadSetting("Resolution", "false"));
            Settings.SendKeysAndMouse = bool.Parse(LoadSetting("SendKeysAndMouse", "true"));
            Settings.LeftMenu = bool.Parse(LoadSetting("LeftMenu", "false"));
            Settings.IP = LoadSetting("IP", "127.0.0.1");
            Settings.Password = LoadSetting("ID", "secret");
        }

        public static void SaveProfile()
        {
            string Key = $"{Settings.IP}_{Settings.ScreenClientX}_{Settings.ScreenClientY}";
            SaveSetting(Key, $"{Settings.ScreenServerX}_{Settings.ScreenServerY}");
        }

        public static void LoadProfile()
        {
            string Key = $"{Settings.IP}_{Settings.ScreenClientX}_{Settings.ScreenClientY}";
            string Value = LoadSetting(Key, "");
            if (Value.Length == 0)
            {
                 Settings.ScreenServerX = Settings.ScreenClientX;
                Settings.ScreenServerY = Settings.ScreenClientY;
                SaveProfile();
                return;
            }
            string[] Data = Value.Split('_');
            Settings.ScreenServerX = int.Parse(Data[0]);
            Settings.ScreenServerY = int.Parse(Data[1]);
        }

        public static void SaveSetting(string Name, string Value)
        {
            try
            {
                RegistryKey Root = Registry.CurrentUser.CreateSubKey(MainProgramName);
                Root.SetValue(Name, Value);
            }
            catch {; }
        }

        public static string LoadSetting(string Name, string Default)
        {
            try
            {
                RegistryKey Root = Registry.CurrentUser.CreateSubKey(MainProgramName);
                return Root.GetValue(Name)?.ToString() ?? Default;
            }
            catch
            {
                SaveSetting(Name, Default);
                return Default;
            }
        }
    }
}
