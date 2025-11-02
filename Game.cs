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

        public MenuHandler MenuHandler
        {
            get { return _menuHandler; }
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

            if (_menuHandler.Main.HostGame.Clicked()) _session = new Host();
            if (_menuHandler.Main.JoinGame.Clicked()) _session = new Client();

            if (_session != null && _menuHandler.Main.Visible)
            {
                _session.UDP.Close();
                _session = null;
            } 
        }
        
        private void UpdateSession()
        {
            if (_session == null) return;

            _session.Update();
        }
    }
}