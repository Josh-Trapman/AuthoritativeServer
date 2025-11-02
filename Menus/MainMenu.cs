using Network;
using SplashKitSDK;

namespace Menus
{
    public class MainMenu : BaseMenu, IMenu
    {
        private bool _requestQuit;
        private bool _createHost;
        private bool _createClient;
        private Button _host;
        private Button _join;
        private Button _exit;

        public MainMenu()
        {
            _host = new Button(20, 20, 80, 40, "Host");
            _join = new Button(20, 70, 80, 40, "Join");
            _exit = new Button(20, 120, 80, 40, "Quit");

            _buttons = new List<Button>() { _host, _join, _exit };
        }

        public bool RequestQuit
        {
            get { return _requestQuit; }
            set { _requestQuit = value; }
        }

        public bool CreateHost
        {
            get { return _createHost; }
            set { _createHost = value; }
        }

        public bool CreateClient
        {
            get { return _createClient; }
            set { _createClient = value; }
        }

        public void Update()
        {
            if (_exit.Clicked()) _requestQuit = true;
            else if (_join.Clicked()) _createClient = true;
            else if (_host.Clicked()) _createHost = true;
        }
        
        public IUDP? NewSession()
        {
            if (_createClient)
            {
                _createClient = false;
                return new Client();
            }
            else if (_createHost)
            {
                _createClient = false;
                return new Host();
            } 
            
            return null;
        }
    }
}