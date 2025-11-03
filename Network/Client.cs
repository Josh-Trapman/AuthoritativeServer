using System.Net;
using System.Net.Sockets;
using System.Text;
 

namespace Network
{
    public class Client : BaseUDP, IUDP
    {
        private List<int> _lobbies;
        public Client()
        {
            _lobbies = new List<int>();
            UDP.Client.Bind(new IPEndPoint(IPAddress.Any, BROADCAST_PORT));
        }

        public UdpClient UDP
        {
            get { return _udp; }
        }

        public List<int> Lobbies
        {
            get { return _lobbies; }
        }

        public void Update()
        {
            GetLobbies();
        }

        public void GetLobbies()
        {
            try
            {
                while (_udp.Available > 0)
                {
                    byte[] msg = _udp.Receive(ref _broadcastEP);
                    string lobby = Encoding.ASCII.GetString(msg);
                    
                    if (!_lobbies.Contains(Convert.ToInt32(lobby)))
                    {
                        _lobbies.Add(Convert.ToInt32(lobby));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}