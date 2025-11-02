using System.Net;
using System.Net.Sockets;
using System.Text;
 

namespace Network
{

    public class Client : BaseUDP, IUDP
    {
        public Client()
        {
            UDP.Client.Bind(new IPEndPoint(IPAddress.Any, BROADCAST_PORT));
        }

        public UdpClient UDP
        {
            get { return _udp; }
        }

        public void Update()
        {
            DisplayLobbies();
        }

        public void DisplayLobbies()
        {
            try
            {
                byte[] msg = _udp.Receive(ref _broadcastEP);
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