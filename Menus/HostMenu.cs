namespace Menus
{
    public class HostMenu : BaseMenu, IMenu
    {
        private Button _endHost;
        private Button _startGame;

        public HostMenu()
        {
            _endHost = new Button(20, 20, 80, 40, "Back");
            _startGame = new Button(20, 70, 80, 40, "Start");

            _buttons = new List<Button> { _endHost, _startGame };
        }

        public Button EndHost
        {
            get { return _endHost; }
        }

        public Button StartGame
        {
            get { return _startGame; }
        }
    }
}