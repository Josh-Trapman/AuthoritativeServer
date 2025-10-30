using System.Net;
using System.Net.Sockets;

namespace GameApp
{
    public class Host
    {
        private readonly UdpClient _udp;
        private readonly IPEndPoint _broadcastEP;

        public Host()
        {
            _udp = new(11000);
            _broadcastEP = new IPEndPoint(IPAddress.Broadcast, 0);
        }

        public void BroadcastLobby()
        {
            try
            {
                byte[] bytes = new byte[] { 0b101 };
                _udp.Send(bytes, bytes.Length, _broadcastEP);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}