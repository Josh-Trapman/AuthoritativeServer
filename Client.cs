using System.Buffers;
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

        

    }
}