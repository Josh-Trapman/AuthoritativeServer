using SplashKitSDK;
using Global;

namespace Menus
{
    public class JoinMenu : BaseMenu, IMenu
    {
        private Button _back;
        private List<Lobby> _lobbies;

        public JoinMenu()
        {
            _lobbies = new List<Lobby>();
            _back = new Button(20, 20, 80, 40, "Back");

            _buttons = new List<Button> { _back };
        }

        public Button Back
        {
            get { return _back; }
        }

        public List<Lobby> Lobbies
        {
            get { return _lobbies; }
        }

        public void AddLobby(Lobby lobby)
        {
            _lobbies.Add(lobby);
        }

        public void RemoveLobby(Lobby lobby)
        {
            _lobbies.Remove(lobby);
        }

        public override void Draw()
        {
            base.Draw();

            for (int i = 0; i < _lobbies.Count; i++)
            {
                _lobbies[i].Button.X = 200;
                _lobbies[i].Button.Y = i * 60;
                _lobbies[i].DrawButton();
            }
        }
    }
}
