using SplashKitSDK;

namespace Menus
{
    public abstract class BaseMenu
    {
        protected List<Button> _buttons = [];
       

        public List<Button> Buttons
        {
            get { return _buttons; }
        }

        public virtual void Draw()
        {

            foreach (Button button in _buttons)
            {
                button.Draw();
            }
            
        }
    }
}