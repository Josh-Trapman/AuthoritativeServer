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
            MainMenuEvents();
            HostMenuEvents();
            JoinMenuEvents();         
        }

        public void MainMenuEvents()
        {
            if (_menu is MainMenu menu)
            {
                if (menu.HostGame.Clicked())
                {
                    OpenMenu(new HostMenu());
                }
                if (menu.JoinGame.Clicked())
                {
                    OpenMenu(new JoinMenu());
                }
            }
        }

        public void HostMenuEvents()
        {
            if (_menu is HostMenu host)
            {
                if (host.EndHost.Clicked())
                {
                    OpenMenu(new MainMenu());
                }
            }
        }

        public void JoinMenuEvents()
        {
            if (_menu is JoinMenu join)
            {
                if (join.Back.Clicked())
                {
                    OpenMenu(new MainMenu());
                }
            }
        }

        private void OpenMenu(IMenu menuToOpen)
        {
            SplashKit.ProcessEvents();
            _menu = menuToOpen;
        }

        public override void Draw()
        {
            _menu.Draw();
        }
    }
}