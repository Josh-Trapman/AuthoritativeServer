using System.Net;
using System.Net.Sockets;

namespace Network
{
    public abstract class BaseUDP
    {
        protected IPEndPoint _broadcastEP;
        protected readonly UdpClient _udp;
        protected const int BROADCAST_PORT = 56767;

        public BaseUDP()
        {
            _udp = new UdpClient();
            _broadcastEP = new IPEndPoint(IPAddress.Broadcast, BROADCAST_PORT);
        }
    }
}