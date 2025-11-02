using SplashKitSDK;

namespace Menus
{
    public abstract class BaseMenu
    {
        private bool _visible;
        protected List<Button> _buttons = [];
       
        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public virtual void Draw()
        {
            if (_visible)
            {
                foreach (Button button in _buttons)
                {
                    button.Draw();
                }
            }
        }
    }
}