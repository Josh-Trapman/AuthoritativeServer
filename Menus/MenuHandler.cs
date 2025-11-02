using SplashKitSDK;

namespace Menus
{
    public class MenuHandler : BaseMenu
    {
        private MainMenu _main;
        private HostMenu _host;
        private JoinMenu _join;
        private LobbyMenu _lobby;
        private List<IMenu> _menus;

        public MenuHandler()
        {
            _main = new();
            _host = new();
            _join = new();
            _lobby = new();

            _main.Visible = true;

            _menus = new List<IMenu>() { _main, _host, _join, _lobby };
        }

        public MainMenu Main
        {
            get { return _main; }
        }
        

        public override void Draw()
        {
            foreach (IMenu menu in _menus)
            {
                if (menu.Visible)
                    menu.Draw();
            }
        }

        public void Update()
        {
            if (_main.Visible) _main.Update();
            else if (_join.Visible) _join.Update();
            else if (_host.Visible) _host.Update();
            else if (_lobby.Visible)_lobby.Update();
        }
    }
}