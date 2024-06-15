using System;
using System.Net;
using System.Security.Principal;
using System.Windows.Forms;

namespace Client
{
    public static class Untils
    {
        public static bool IsIP4Address(string host)
        {
            if (host.Split('.').Length != 4 || host.Length > 15 || host.ToLower().IndexOf(".com") > 1)
                return false;

            IPAddress ip;
            return IPAddress.TryParse(host, out ip);
        }

        // Perform XOR encryption or decryption on a string
        public static string XorString(string value, int shift, bool outbound)
        {
            // Replace spaces with a special character if outbound flag is set
            if (outbound)
                value = value.Replace(" ", "#SS#");

            string output = string.Empty;
            int character = 0;

            for (int i = 0; i < value.Length; i++)
            {
                character = Convert.ToInt32(value[i]);

                // Perform different XOR operation based on the outbound flag and specific character values
                if (outbound && character == 113)
                    character = Convert.ToInt32('¬');
                else if (!outbound && character == 172)
                    character = 113;
                else
                    character ^= shift;

                output += char.ConvertFromUtf32(character);
            }

            // Replace the special character with spaces if outbound flag is not set
            if (!outbound)
                return output.Replace("#SS#", " ");
            else
                return output;
        }

        public static string GetIP(string host)
        {
            try
            {
                IPHostEntry ipEntry = Dns.GetHostEntry(host);
                foreach (IPAddress ip in ipEntry.AddressList)
                {
                    // Return the first IPv4 address found
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        return ip.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return string.Empty;
        }

        public static bool IsUserAdministrator()
        {
            try
            {
                WindowsIdentity user = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(user);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }
    }
}
