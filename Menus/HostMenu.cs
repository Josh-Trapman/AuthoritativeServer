namespace Menus
{
    public class HostMenu : BaseMenu, IMenu
    {
        private Button _endHost;

        public HostMenu()
        {
            _endHost = new Button(20, 20, 80, 40, "Back");

            _buttons = new List<Button> { _endHost };
        }

        public Button EndHost
        {
            get { return _endHost; }
        }
    }
}