using System.Runtime.InteropServices;
using Microsoft.Win32;

public sealed class Wallpaper
{
    // Used to handle wallpaper
    // Constants for setting the wallpaper
    private const int SPI_SETDESKWALLPAPER = 20;
    private const int SPIF_UPDATEINIFILE = 0x01;
    private const int SPIF_SENDWININICHANGE = 0x02;

    // Variables to store wallpaper settings
    private static string wallpaperStyle = string.Empty;
    private static string wallpaperFileName = string.Empty;
    private static string tileWallpaper = string.Empty;
    public static string background = string.Empty;
    public static bool switched = false;

    // External method for setting the wallpaper
    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    // Enumeration for wallpaper styles
    public enum Style : int
    {
        Tiled,
        Centered,
        Stretched
    }

    // Method to save current wallpaper settings
    public static void SaveWallpaper()
    {
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        wallpaperStyle = key.GetValue("WallpaperStyle", string.Empty).ToString();
        wallpaperFileName = key.GetValue("Wallpaper", string.Empty).ToString();
        tileWallpaper = key.GetValue("TileWallpaper", string.Empty).ToString();
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        background = key.GetValue("BackGround", string.Empty).ToString();
    }

    // Method to set a black wallpaper
    public static void SetWallpaper()
    {
        if (wallpaperStyle.Length == 0) return; // If settings have not been saved, return
        switched = true;

        // Set wallpaper-related registry values
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        key.SetValue("Wallpaper", string.Empty);
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        key.SetValue("BackGround", "0 0 0");

        // Set the black wallpaper
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, string.Empty, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
    }

    // Method to restore previous wallpaper settings
    public static void RestoreWallpaper()
    {
        if (wallpaperStyle.Length == 0 || !switched) return; // If settings have not been saved or not switched, return

        // Restore original wallpaper-related registry values
        RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
        key.SetValue("WallpaperStyle", wallpaperStyle);
        key.SetValue("Wallpaper", wallpaperFileName);
        key.SetValue("TileWallpaper", tileWallpaper);
        key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Colors", true);
        key.SetValue("BackGround", background);

        // Set the restored wallpaper
        SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, wallpaperFileName, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        switched = true;
    }
}
