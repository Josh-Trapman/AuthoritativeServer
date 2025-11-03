using System.Net.Mail;
using Network;
using SplashKitSDK;

namespace Menus
{
    public class MenuHandler : BaseMenu
    {
        private IMenu _menu;

        public MenuHandler()
        {


            _menu = new MainMenu();

        }

        public IMenu Menu
        {
            get { return _menu; }
        }

        public void Update()
        {
            if (_menu is MainMenu menu)
            {
                if (menu.HostGame.Clicked())
                {
                    _menu = new HostMenu();
                }
                if (menu.JoinGame.Clicked())
                {
                    _menu = new JoinMenu();
                }
            }

            if (_menu is HostMenu host)
            {
                if (host.EndHost.Clicked())
                {
                    _menu = new MainMenu();
                }
            }

            if (_menu is JoinMenu join)
            {
                if (join.Back.Clicked())
                {
                    _menu = new MainMenu();
                }
            }
        }

        public override void Draw()
        {
            _menu.Draw();
        }
    }
}