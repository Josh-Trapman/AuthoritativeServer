using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Numerics;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Server
    {
        private readonly UdpClient _udp;
        private List<Client> _clients;
        private IPEndPoint _ep;
        private Vector2 _movement;
        private Vector2 _clientPos;

        public Server()
        {
            _udp = new(11000);
            _ep = new(IPAddress.Any, 11000);
            _clients = new();
            _clientPos = new();
        }

        public void AddClient(Client client)
        {
            _clients.Add(client);
        }

        public void Update(float dt)
        {
            foreach (Client client in _clients)
            {
                if ((client.Position - _clientPos).Length() >= 0.1f)
                {
                    Console.WriteLine($"{client.Position} | {_clientPos}");
                    client.Position = _clientPos;
                    _movement = Vector2.Zero;
                    continue;

                }
                
                _clientPos += _movement * dt * 100f;
                client.Position += _movement * dt * 100f;
                _movement = Vector2.Zero;
            }
        }

        public void Draw()
        {
            foreach (Client client in _clients)
            {
                client.Draw();
            }
        }

        public async Task StartReceive()
        {

            try
            {
                while (true)
                {
                    UdpReceiveResult result = await _udp.ReceiveAsync();
                    string pos = Encoding.UTF8.GetString(result.Buffer);
                    string[] mov = pos.Split(",");
                    if (mov.Length >= 2)
                    {
                        _clientPos.X = float.Parse(mov[0]);
                        _clientPos.Y = float.Parse(mov[1]);

                        _movement.X = float.Parse(mov[2]);
                        _movement.Y = float.Parse(mov[3]);
                    }
                    // Console.WriteLine($"Message received: {msg}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }
            
        }
    }
}
