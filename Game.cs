
using System.Drawing;
using System.Net;
using System.Text;
using Menus;
using Global;
using Network;
using System.Security.Cryptography.X509Certificates;

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

            else if (_menuHandler.Menu is HostMenu && _session == null)
            {
                Console.WriteLine("Host created");
                _session = new Host();
            }

            else if (_menuHandler.Menu is JoinMenu join)
            {
                Lobby? joinLobby = null;
                if (_session == null)
                {
                    Console.WriteLine("Client created");
                    _session = new Client();
                }

                foreach (Lobby lobby in join.Lobbies)
                {
                    if (lobby.Button.Clicked()) joinLobby = lobby;
                }

                if (_session is Client client)
                {
                    UpdateJoinableLobbies(join, client);

                    if (joinLobby != null)
                    {
                        client.RequestJoin(joinLobby);
                    }
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
            menu.Lobbies.Clear();
            foreach (Lobby lobby in client.Lobbies)
            {
                if (!menu.Lobbies.Contains(lobby))
                {
                    menu.AddLobby(lobby);
                }
                else
                {
                    
                }
            }
        }
    }
}