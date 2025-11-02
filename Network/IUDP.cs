using System.Net.Sockets;

namespace Network
{
    public interface IUDP
    {
        public UdpClient UDP { get; }

        public void Update();
    }
}