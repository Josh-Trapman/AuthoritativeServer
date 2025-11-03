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
                if (game.MenuHandler.Menu is MainMenu main && main.Exit.Clicked()) return;

                SplashKit.ClearScreen();

                game.Draw();

                SplashKit.RefreshScreen(60);
            }
          
        }
    }
}
