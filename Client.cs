using System;
using System.Net;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Client
    {
        private readonly UdpClient _udp;
        private readonly IPEndPoint _ep;
        private Vector2 _position;
        private Vector2 _lastPosition;
        private readonly int _id;

        public Client()
        {
            _udp = new(0);
            _ep = new(IPAddress.Parse("127.0.0.11"), 11000);
            _lastPosition = Vector2.Zero;
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public float X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }

        public float Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public int Id
        {
            get { return _id; }
        }

        public void SendMessage(float dt)
        {
            Vector2 movement = Move();
            _position += movement * dt * 100f;
            try
            {
                string msg = $"{X},{Y},{movement.X},{movement.Y}";
                byte[] datagram = Encoding.UTF8.GetBytes(msg);

                if (_position != _lastPosition)
                {
                    _udp.Send(datagram, datagram.Length, _ep);
                    _lastPosition = _position;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}");
            }

        }

        public Vector2 Move()
        {
            Vector2 movement = Vector2.Zero;

            if (SplashKit.KeyDown(KeyCode.WKey)) movement.Y -= 1;
            if (SplashKit.KeyDown(KeyCode.AKey)) movement.X -= 1;
            if (SplashKit.KeyDown(KeyCode.SKey)) movement.Y += 1;
            if (SplashKit.KeyDown(KeyCode.DKey)) movement.X += 1;

            return movement;
        }
        
        public void Draw()
        {
            SplashKit.FillCircle(Color.Red, X, Y, 20);
        }
    }
}
