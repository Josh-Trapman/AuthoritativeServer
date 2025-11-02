namespace Menus
{
    public class HostMenu : BaseMenu, IMenu
    {
        private Button _endHost;
        private Button _startGame;

        public HostMenu()
        {
            _endHost = new Button(20, 20, 80, 40, "Back");
            _startGame = new Button(20, 20, 80, 40, "Start");

            _buttons = new List<Button> { _endHost, _startGame };
        }

        public void Update()
        {
            if (_endHost.Clicked()) ;
        }
    }
}