using System;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Program
    {
        public static void Main()
        {
            Client client = new();
            Server server = new();
            server.AddClient(client);

            Window window = new("Name", 200, 200);

            SplashKitSDK.Timer timer = new("delta");
            timer.Start();

            _ = Task.Run(async () => await server.StartReceive());

            do
            {
                SplashKit.ProcessEvents();
                float dt = timer.Ticks / 1000.0f;
                timer.Reset();


                client.SendMessage(dt);
                server.Update(dt);

                SplashKit.ClearScreen();
                client.Draw();
                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);
        }
    }
}
