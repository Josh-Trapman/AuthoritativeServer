using Network;
using SplashKitSDK;

namespace Menus
{
    public class MainMenu : BaseMenu, IMenu
    {
        private Button _hostGame;
        private Button _joinGame;
        private Button _exit;

        public MainMenu()
        {
            _hostGame = new Button(20, 20, 80, 40, "Host");
            _joinGame = new Button(20, 70, 80, 40, "Join");
            _exit = new Button(20, 120, 80, 40, "Quit");

            _buttons = new List<Button>() { _hostGame, _joinGame, _exit };
        }

        public Button HostGame
        {
            get { return _hostGame; }
        }

        public Button JoinGame
        {
            get { return _joinGame; }
        }

        public Button Exit
        {
            get { return _exit; }
        }
    }
}