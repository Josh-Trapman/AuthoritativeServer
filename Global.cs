using System.Net;
using System.Net.Sockets;

namespace Global
{
    public class Functions
    {
        public static string GetIPv4Address()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            try
            {
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return ip.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get ipv4 Error " + ex.Message);
            }

            return "";
        }
    }
}
