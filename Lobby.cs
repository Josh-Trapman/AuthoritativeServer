using Menus;

namespace Global
{
    public class Lobby
    {
        private int _id;
        private string _host;
        private int _maxPlayers;
        private int _currentPlayers;
        private LobbyButton _button;

        public Lobby(int id, string host, int maxPlayers)
        {
            _id = id;
            _host = host;
            _maxPlayers = maxPlayers;
            _currentPlayers = 1;

            _button = new LobbyButton(0, 0, 100, 50, _host + _currentPlayers + "/" + _maxPlayers);
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        public int MaxPlayers
        {
            get { return _maxPlayers; }
            set { _maxPlayers = value; }
        }

        public int CurrentPlayers
        {
            get { return _currentPlayers; }
            set { _currentPlayers = value; }
        }

        public LobbyButton Button
        {
            get { return _button; }
        }

        public void DrawButton()
        {
            _button.Draw();
        }

        public void UpdateText(string[] msg)
        {
            _currentPlayers = Convert.ToInt32(msg[3]);
            _button.Text = _currentPlayers.ToString();
        }
    }
}