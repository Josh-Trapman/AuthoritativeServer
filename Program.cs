using System;
using GameApp;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new("Name", 200, 200);
            Client client = new();
            Host host = new();

            SplashKitSDK.Timer timer = new("delta");
            timer.Start();


            do
            {
                SplashKit.ProcessEvents();
                float dt = timer.Ticks / 1000.0f;
                timer.Reset();

                host.BroadcastLobby();


                SplashKit.ClearScreen();
                
                SplashKit.RefreshScreen(60);

            } while (!window.CloseRequested);
        }
    }
}
