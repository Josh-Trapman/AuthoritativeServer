using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using Global;
using static Global.Functions;
using System.Text;

namespace Network
{
    public class Host : BaseUDP, IUDP
    {
        private int _tick;
        private int _maxPlayers = 2;
        private int _currentPlayers = 1;
        private Lobby _lobby;
        private IPEndPoint _ep;
        private Stopwatch _broadcastTimer;
        


        private const int BROADCAST_DELAY = 1000;

        public Host()
        {
            _ep = new IPEndPoint(IPAddress.Any, 0);
            _udp.Client.Bind(_ep);

            if (_udp.Client.LocalEndPoint != null)
            {
                _ep = (IPEndPoint)_udp.Client.LocalEndPoint;
            }

            _lobby = new Lobby(_ep.Port, Dns.GetHostName(), _maxPlayers);

            _broadcastTimer = new Stopwatch();
            _broadcastTimer.Start();

        }

        public void Update()
        {
            ReceiveMessages();
            BroadcastLobby();
        }

        public void ReceiveMessages()
        {
            try
            {
                while (_udp.Available > 0)
                {
                    byte[] datagram = _udp.Receive(ref _ep);
                    string msg = Encoding.ASCII.GetString(datagram);

                    if (msg.Split(",").Length == 1) AckJoinRequest(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        public void SendMessage(string message, IPEndPoint endPoint)
        {
            try
            {
                byte[] datagram = Encoding.ASCII.GetBytes(message);
                _udp.Send(datagram, datagram.Length, endPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request Join error" + ex.Message);
            }

        }

        public void AckJoinRequest(string message)
        {
            Console.WriteLine(message + " requested to join.");

            if (_lobby.CurrentPlayers < _lobby.MaxPlayers)
            {
                AllowJoin(message);
            }
        }
        
        public void AllowJoin(string ip)
        {
            SendMessage($"{GetIPv4Address},{_ep.Port + 1}", new IPEndPoint(IPAddress.Parse(ip), BROADCAST_PORT));
            _lobby.CurrentPlayers++;
        }

        public void BroadcastLobby()
        {
            if (_broadcastTimer.ElapsedMilliseconds >= BROADCAST_DELAY)
            {
                _udp.EnableBroadcast = true;
                SendMessage($"{_lobby.Id},{_lobby.Host},{_lobby.MaxPlayers},{_currentPlayers}", _broadcastEP);

                _broadcastTimer.Restart();
                _tick++;
            }
        }
    }
}