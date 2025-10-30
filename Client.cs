using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
 

namespace Network
{

    public class Client
    {

        private readonly UdpClient _udp;
        
        private const int DEFAULT_PORT = 56767;



        public Client()
        {
            _udp = new(DEFAULT_PORT);
        }

        public void DisplayLobbies()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, DEFAULT_PORT);
                byte[] msg = _udp.Receive(ref endPoint);
                string lobby = Encoding.ASCII.GetString(msg);

                Console.WriteLine(lobby);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}