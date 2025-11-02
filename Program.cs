using Network;
using Menus;
using SplashKitSDK;

namespace AuthoritativeServer
{
    public class Program
    {

        public static void Main()
        {
            Window window = new Window("Game", 700, 700);
            Game game = new Game();

            while (!window.CloseRequested)
            {
                SplashKit.ProcessEvents();

                game.Update();
                if (game.MenuHandler.Main.Exit.Clicked()) return;

                SplashKit.ClearScreen();

                game.Draw();

                SplashKit.RefreshScreen(60);
            }

            // BaseUDP? udp = JoinOrHost();

            // if (udp is Host)
            // {
            //     udp = (Host)udp;
            // }
            // else if (udp is Client)
            // {
            //     udp = (Client)udp;
            // }

            // while (true)
            // {
            //     if (udp == null) return;

            //     udp.Update();


            // }            
        }
    }
}
