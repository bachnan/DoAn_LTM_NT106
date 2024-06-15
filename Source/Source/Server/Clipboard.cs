using System;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    // Class responsible for asynchronous clipboard operations
    public class ClipboardAsync
    {
        private string getText;
        private string setText;

        // Sets the text on the clipboard
        private void SetTextOnClipboard()
        {
            // Clear the clipboard and set the text
            Clipboard.Clear();
            Clipboard.SetText(setText);
        }

        // Gets the text from the clipboard
        private void GetTextFromClipboard(object format)
        {
            try
            {
                if (format == null)
                {
                    // Get the text from the clipboard without specifying a format
                    getText = Clipboard.GetText();
                }
                else
                {
                    // Get the text from the clipboard with the specified format
                    getText = Clipboard.GetText((TextDataFormat)format);
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, set the text to empty and display an error message
                getText = string.Empty;
                MessageBox.Show(ex.Message);
            }
        }

        // Gets the text from the clipboard without specifying a format
        public static string GetText()
        {
            ClipboardAsync instance = new ClipboardAsync();
            Thread staThread = new Thread(instance.GetTextFromClipboard);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
            return instance.getText;
        }

        // Sets the text on the clipboard
        public static void SetText(string receivedText)
        {
            ClipboardAsync instance = new ClipboardAsync();
            instance.setText = receivedText;
            Thread staThread = new Thread(instance.SetTextOnClipboard);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }

        // Gets the text from the clipboard with the specified format
        public string GetText(TextDataFormat format)
        {
            ClipboardAsync instance = new ClipboardAsync();
            Thread staThread = new Thread(instance.GetTextFromClipboard);
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start(format);
            staThread.Join();
            return instance.getText;
        }
    }
}
