using System.Linq.Expressions;
using Global;
using SplashKitSDK;

namespace Menus
{
    public class LobbyButton : Button
    {
        public LobbyButton(float x, float y, int width, int height, string text) : base(x, y, width, height, text)
        { }

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
    }
}