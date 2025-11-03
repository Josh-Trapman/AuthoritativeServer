
using System.Drawing;
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
            _session = null;
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
            _menuHandler.Draw();
        }

        private void UpdateMenus()
        {
            _menuHandler.Update();
            if (_menuHandler.Menu is MainMenu && _session != null)
            {
                _session.UDP.Close();
                _session = null;
            }
            if (_menuHandler.Menu is HostMenu host && _session == null)
            {
                Console.WriteLine("Host created");
                _session = new Host();
            }
            if (_menuHandler.Menu is JoinMenu join)
            {
                if (_session == null)
                {
                    Console.WriteLine("Client created");
                    _session = new Client();

                }
                
                if (_session is Client client)
                {
                    UpdateJoinableLobbies(join, client);
                }

            }
        }

        private void UpdateSession()
        {
            if (_session == null) return;

            _session.Update();
        }
        
        public void UpdateJoinableLobbies(JoinMenu menu, Client client)
        {
            foreach (int lobby in client.Lobbies)
            {
                menu.AddLobby(lobby);
            }
        }
    }
}