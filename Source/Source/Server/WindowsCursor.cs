using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

public class WindowsCursor
{
    [StructLayout(LayoutKind.Sequential)]
    struct CURSORINFO
    {
        public Int32 cbSize;
        public Int32 flags;
        public IntPtr hCursor;
        public POINTAPI ptScreenPos;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct POINTAPI
    {
        public int x;
        public int y;
    }

    [DllImport("user32.dll", SetLastError = true)]
    static extern bool DrawIconEx(IntPtr hdc, int xLeft, int yTop, IntPtr hIcon, int cxWidth, int cyHeight, int istepIfAniCur, IntPtr hbrFlickerFreeDraw, int diFlags);

    private const Int32 CURSOR_SHOWING = 0x0001;
    private const Int32 DI_NORMAL = 0x0003;

    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(out CURSORINFO pci);

    // Capture the cursor and return its color
    public static Color CaptureCursor(ref int X, ref int Y, Graphics theShot, int ScreenServerX, int ScreenServerY)
    {
        IntPtr C = Cursors.Arrow.Handle;
        CURSORINFO pci;
        pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));

        if (GetCursorInfo(out pci))
        {
            X = pci.ptScreenPos.x;
            Y = pci.ptScreenPos.y;

            // Check the cursor type and return the corresponding color
            if (pci.hCursor == Cursors.Default.Handle)
                return Color.Red;
            else if (pci.hCursor == Cursors.WaitCursor.Handle)
                return Color.Green;
            else if (pci.hCursor == Cursors.Arrow.Handle)
                return Color.Blue;
            else if (pci.hCursor == Cursors.IBeam.Handle)
                return Color.White;
            else if (pci.hCursor == Cursors.Hand.Handle)
                return Color.Violet;
            else if (pci.hCursor == Cursors.SizeNS.Handle)
                return Color.Yellow;
            else if (pci.hCursor == Cursors.SizeWE.Handle)
                return Color.Orange;
            else if (pci.hCursor == Cursors.SizeNESW.Handle)
                return Color.Aqua;
            else if (pci.hCursor == Cursors.SizeNWSE.Handle)
                return Color.Pink;
            else if (pci.hCursor == Cursors.PanEast.Handle)
                return Color.BlueViolet;
            else if (pci.hCursor == Cursors.HSplit.Handle)
                return Color.Cyan;
            else if (pci.hCursor == Cursors.VSplit.Handle)
                return Color.DarkGray;
            else if (pci.hCursor == Cursors.Help.Handle)
                return Color.DarkGreen;
            else if (pci.hCursor == Cursors.AppStarting.Handle)
                return Color.SlateGray;

            if (pci.flags == CURSOR_SHOWING)
            {
                // Capture the mouse image and embed it in the screen shot of the desktop because it's a custom mouse cursor
                float XReal = pci.ptScreenPos.x * (float)ScreenServerX / (float)Screen.PrimaryScreen.Bounds.Width - 11;
                float YReal = pci.ptScreenPos.y * (float)ScreenServerY / (float)Screen.PrimaryScreen.Bounds.Height - 11;
                int x = Screen.PrimaryScreen.Bounds.X;
                var hdc = theShot.GetHdc();
                DrawIconEx(hdc, (int)XReal, (int)YReal, pci.hCursor, 0, 0, 0, IntPtr.Zero, DI_NORMAL);
                theShot.ReleaseHdc();
            }

            return Color.Black;
        }

        // If cursor info cannot be retrieved, set X and Y to 0 and return black color
        X = 0;
        Y = 0;
        return Color.Black;
    }

    // Convert color to cursor
    public static Cursor ColorToCursor(Color C)
    {
        // Convert the color to ARGB value and compare with predefined colors to determine the cursor type
        int argb = C.ToArgb();

        if (argb == Color.Red.ToArgb())
            return Cursors.Default;
        else if (argb == Color.Green.ToArgb())
            return Cursors.WaitCursor;
        else if (argb == Color.Blue.ToArgb())
            return Cursors.Arrow;
        else if (argb == Color.White.ToArgb())
            return Cursors.IBeam;
        else if (argb == Color.Violet.ToArgb())
            return Cursors.Hand;
        else if (argb == Color.Yellow.ToArgb())
            return Cursors.SizeNS;
        else if (argb == Color.Orange.ToArgb())
            return Cursors.SizeWE;
        else if (argb == Color.Aqua.ToArgb())
            return Cursors.SizeNESW;
        else if (argb == Color.Pink.ToArgb() || C.B == 206)
            return Cursors.SizeNWSE;
        else if (argb == Color.BlueViolet.ToArgb())
            return Cursors.PanEast;
        else if (argb == Color.Cyan.ToArgb())
            return Cursors.HSplit;
        else if (argb == Color.DarkGray.ToArgb())
            return Cursors.VSplit;
        else if (argb == Color.DarkGreen.ToArgb())
            return Cursors.Help;
        else if (argb == Color.SlateGray.ToArgb())
            return Cursors.AppStarting;
        else if (argb == Color.Fuchsia.ToArgb())
            return Cursors.No;

        // If no match found, return the default cursor
        return Cursors.Default;
    }
}
