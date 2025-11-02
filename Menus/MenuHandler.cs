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

            Visible = true;
            _main.Visible = true;

            _menus = new List<IMenu>() { _main, _host, _join, _lobby };
        }

        public MainMenu Main
        {
            get { return _main; }
        }

        public HostMenu Host
        {
            get { return _host; }
        }

        public JoinMenu Join
        {
            get { return _join; }
        }

        public LobbyMenu Lobby
        {
            get { return _lobby; }
        }

        public void Update()
        {
            if (_main.Visible)
            {
                if (_main.HostGame.Clicked())
                {
                    ShowMenu(_host);
                }
                if (_main.JoinGame.Clicked())
                {
                    ShowMenu(_join);
                }
            }

            if (_host.Visible)
            {
                if (_host.EndHost.Clicked())
                {
                    ShowMenu(_main);
                }
            }

            if (_join.Visible)
            {
                if (_join.Back.Clicked())
                {
                    ShowMenu(_main);
                }
            }
        }
        
        public void ShowMenu(IMenu menu)
        {
            SplashKit.ProcessEvents();
            foreach (IMenu m in _menus)
            {
                m.Visible = false;
            }

            menu.Visible = true;
        }

        public override void Draw()
        {
            foreach (IMenu menu in _menus)
            {
                menu.Draw();
            }
        }
    }
}