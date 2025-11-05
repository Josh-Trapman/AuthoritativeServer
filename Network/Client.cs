using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using Global;
using static Global.Functions;
using Menus;

namespace Network
{
    public class Client : BaseUDP, IUDP
    {
        private List<Lobby> _lobbies;
        private IPEndPoint _sendEP;

        public Client()
        {
            _lobbies = new List<Lobby>();
            _sendEP = new IPEndPoint(IPAddress.Any, 0);

            _udp.Client.Bind(new IPEndPoint(IPAddress.Any, BROADCAST_PORT));
        }

        public List<Lobby> Lobbies
        {
            get { return _lobbies; }
        }

        public void Update()
        {
            ReceiveMessages();
        }

        public void RequestJoin(Lobby lobby)
        {
            try
            {
                byte[] datagram = Encoding.ASCII.GetBytes($"{GetIPv4Address()}");
                _sendEP = new IPEndPoint(IPAddress.Broadcast, lobby.Id);

                _udp.Send(datagram, datagram.Length, _sendEP);
                Console.WriteLine("Request sent to " + _sendEP.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Request Join error" + ex.Message);
            }

        }

        public void ReceiveMessages()
        {
            try
            {
                while (_udp.Available > 0)
                {
                    byte[] datagram = _udp.Receive(ref _broadcastEP);
                    string msg = Encoding.ASCII.GetString(datagram);

                    if (msg.Split(",").Length == 4) GetLobbies(msg);
                    else if (msg.Split(",").Length == 2) LinkToHost(msg);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("hi" + ex.Message);
            }
            
            
        }
        
        public void LinkToHost(string message)
        {
            string[] msg = message.Split(",");

            _udp.Client.Bind(new IPEndPoint(IPAddress.Any, Convert.ToInt32(msg[1])));
            _udp.Connect(IPAddress.Parse(msg[0]), _sendEP.Port);
        }


        public void GetLobbies(string message)
        {
            string[] msg = message.Split(",");

            Lobby lobby = new Lobby(Convert.ToInt32(msg[0]), msg[1], Convert.ToInt32(msg[2]));
            _lobbies.Clear();

            if (!_lobbies.Contains(lobby) && lobby.Id != BROADCAST_PORT)
            {
                _lobbies.Add(lobby);
            }
            else if (_lobbies.Contains(lobby))
            {
                lobby.UpdateText(msg);
            }
        }
    }
}