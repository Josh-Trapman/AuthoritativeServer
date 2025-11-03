using SplashKitSDK;

namespace Menus
{
    public class JoinMenu : BaseMenu, IMenu
    {
        private Button _back;
        private List<int> _lobbies;

        public JoinMenu()
        {
            _lobbies = new List<int>();
            _back = new Button(20, 20, 80, 40, "Back");

            _buttons = new List<Button> { _back };
        }

        public Button Back
        {
            get { return _back; }
        }

        public List<int> Lobbies
        {
            get { return _lobbies; }
        }

        public void AddLobby(int data)
        {
            if (!_lobbies.Contains(data))
            {
                _lobbies.Add(data);
            }
        }

        public override void Draw()
        {
            base.Draw();

            for (int i = 0; i < _lobbies.Count; i++)
            {
                SplashKit.DrawText(_lobbies[i].ToString(), Color.Black, 400, i * 50 + 20);
            }
        }
    }
}
