using System;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public class ClipboardAsync
    {
        private string setText;
        private string getText;

        private void SetTextThread()
        {
            if (setText.Length == 0) return;

            // Clear the clipboard and set the text
            Clipboard.Clear();
            Clipboard.SetText(setText);
        }

        private void GetTextThread(object format)
        {
            try
            {
                if (format == null)
                {
                    getText = Clipboard.GetText();
                }
                else
                {
                    getText = Clipboard.GetText((TextDataFormat)format);
                }
            }
            catch (Exception ex)
            {
                getText = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }

        public static string GetText()
        {
            ClipboardAsync instance = new ClipboardAsync();

            Thread staThread = new Thread(instance.GetTextThread);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();

            return instance.getText;
        }

        public static void SetText(string text)
        {
            ClipboardAsync instance = new ClipboardAsync();
            instance.setText = text;

            Thread staThread = new Thread(instance.SetTextThread);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }

        public string GetText(TextDataFormat format)
        {
            ClipboardAsync instance = new ClipboardAsync();

            Thread staThread = new Thread(instance.GetTextThread);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start(format);
            staThread.Join();

            return instance.getText;
        }
    }
}
