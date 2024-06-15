using System.Runtime.InteropServices;
using Microsoft.Win32;

public sealed class Wallpaper
{
    private const int SPI_SETDESKWALLPAPER = 20;
    private const int SPIF_UPDATEINIFILE = 0x01;
    private const int SPIF_SENDWININICHANGE = 0x02;

    private static string wallpaperStyle = string.Empty;
    private static string wallpaperFileName = string.Empty;
    private static string tileWallpaper = string.Empty;
    public static string background = string.Empty;

    // Import the SystemParametersInfo function from user32.dll
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    // Enum for wallpaper styles
    public enum Style : int
    {
        Tiled,
        Centered,
        Stretched
    }

    // Save the current wallpaper settings
    public static void SaveWallpaper()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        wallpaperStyle = key.GetValue("WallpaperStyle", string.Empty).ToString();
        wallpaperFileName = key.GetValue("Wallpaper", string.Empty).ToString();
        tileWallpaper = key.GetValue("TileWallpaper", string.Empty).ToString();
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        background = key.GetValue("Background", string.Empty).ToString();
    }

    // Set a black wallpaper for the desktop
    public static void SetWallpaper()
    {
        if (wallpaperStyle.Length == 0) return; // If wallpaper settings are not saved, return
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        key.SetValue("Wallpaper", string.Empty);
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        key.SetValue("Background", "0 0 0");
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, string.Empty, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }

    // Restore the previously saved wallpaper settings
    public static void RestoreWallpaper()
    {
        if (wallpaperStyle.Length == 0) return; // If wallpaper settings are not saved, return
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        key.SetValue("WallpaperStyle", wallpaperStyle);
        key.SetValue("Wallpaper", wallpaperFileName);
        key.SetValue("TileWallpaper", tileWallpaper);
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        key.SetValue("Background", background);
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperFileName, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }
}
