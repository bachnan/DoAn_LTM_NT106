using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;

public class WindowsCursor
{
    /* This code defines a class `WindowsCursor` that contains two structs `CURSORINFO` and `POINTAPI`,
    and two methods `CaptureCursor` and `ColorToCursor`. */
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

    [DllImport("user32.dll")]
    static extern bool GetCursorInfo(out CURSORINFO pci);

    public static Color CaptureCursor(ref int X, ref int Y)
    {
        // Capture the color of the cursor and return it
        CURSORINFO pci;
        pci.cbSize = Marshal.SizeOf(typeof(CURSORINFO));
        if (GetCursorInfo(out pci))
        {
            X = pci.ptScreenPos.x;
            Y = pci.ptScreenPos.y;

            // Check the cursor handle and return the corresponding color
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
            else
                return Color.Black;
        }

        // If cursor information is not available, set X and Y to 0 and return black color
        X = 0;
        Y = 0;
        return Color.Black;
    }

    public static Cursor ColorToCursor(Color C)
    {
        // Convert a color to a corresponding cursor
        if (C.ToArgb() == Color.Red.ToArgb())
            return Cursors.Default;
        if (C.ToArgb() == Color.Green.ToArgb())
            return Cursors.WaitCursor;
        if (C.ToArgb() == Color.Blue.ToArgb())
            return Cursors.Arrow;
        if (C.ToArgb() == Color.White.ToArgb())
            return Cursors.IBeam;
        if (C.ToArgb() == Color.Violet.ToArgb())
            return Cursors.Hand;
        if (C.ToArgb() == Color.Yellow.ToArgb())
            return Cursors.SizeNS;
        if (C.ToArgb() == Color.Orange.ToArgb())
            return Cursors.SizeWE;
        if (C.ToArgb() == Color.Aqua.ToArgb())
            return Cursors.SizeNESW;
        if (C.ToArgb() == Color.Pink.ToArgb() || C.B == 206)
            return Cursors.SizeNWSE;
        if (C.ToArgb() == Color.BlueViolet.ToArgb())
            return Cursors.PanEast;
        if (C.ToArgb() == Color.Cyan.ToArgb())
            return Cursors.HSplit;
        if (C.ToArgb() == Color.DarkGray.ToArgb())
            return Cursors.VSplit;
        if (C.ToArgb() == Color.DarkGreen.ToArgb())
            return Cursors.Help;
        if (C.ToArgb() == Color.SlateGray.ToArgb())
            return Cursors.AppStarting;
        if (C.ToArgb() == Color.Fuchsia.ToArgb())
            return Cursors.No;
        if (C.ToArgb() == Color.Black.ToArgb())
            return Cursors.Cross;

        // If no matching color found, return a custom cursor
        byte[] BB = Client.Properties.Resources.ResourceManager.GetObject("CursorUnknown") as byte[];
        return new Cursor(new System.IO.MemoryStream(BB));
    }
}
