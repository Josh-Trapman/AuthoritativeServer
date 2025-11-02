using System.Diagnostics;
using System.Net;
using System.Text;

namespace Network
{
    public class Host : BaseUDP
    {
        private int _tick;
        private int _hostPort;
        private Stopwatch _broadcastTimer;


        private const int BROADCAST_DELAY = 1000;

        public Host()
        {
            UDP.Client.Bind(new IPEndPoint(IPAddress.Any, 0));

            _broadcastTimer = new Stopwatch();
            _broadcastTimer.Start();

            if (_udp.Client.LocalEndPoint is IPEndPoint ep)
            {
                _hostPort = ep.Port;
            }
        }

        public void BroadcastLobby()
        {
            if (_broadcastTimer.ElapsedMilliseconds >= BROADCAST_DELAY)
            {
                try
                {
                    byte[] bytes = Encoding.ASCII.GetBytes($"{_hostPort}");
                    _udp.Send(bytes, bytes.Length, _broadcastEP);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                _broadcastTimer.Restart();
                _tick++;
            }
        }

        public override void Update()
        {
            BroadcastLobby();
        }
    }
}