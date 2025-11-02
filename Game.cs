using Menus;
using Network;

namespace AuthoritativeServer
{
    public class Game
    {
        private MenuHandler _menuHandler;
        private IUDP? _session;

        public Game()
        {
            _menuHandler = new MenuHandler();
        }

        public void Update()
        {
            UpdateMenus();
            UpdateSession();
            
        }

        public void Draw()
        {
            if (_menuHandler.Visible) _menuHandler.Draw();

        }

        private void UpdateMenus()
        {
            if (!_menuHandler.Visible) return;

            _menuHandler.Update();

            IUDP? createSession = _menuHandler.Main.NewSession();
            if (createSession == null) return;

            if (createSession is Client client) _session = client;
            else if (createSession is Host host) _session = host;
        }
        
        private void UpdateSession()
        {
            if (_session == null) return;

            _session.Update();
        }
    }
}