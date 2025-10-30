using System.Buffers;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;

namespace GameApp
{

    public class Client
    {
        private Vector2 _position;

        private readonly UdpClient _udp;


        public Client()
        {
            _udp = new(0);
        }

        public void Listen()
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 11000);
                byte[] msg = _udp.Receive(ref endPoint);
                Console.WriteLine(msg[0]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}