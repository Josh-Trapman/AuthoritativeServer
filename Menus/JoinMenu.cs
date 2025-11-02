namespace Menus
{
    public class JoinMenu : BaseMenu, IMenu
    {
        private Button _back;

        public JoinMenu()
        {
            _back = new Button(20, 20, 80, 40, "Back");

            _buttons = new List<Button> { _back };
        }

        public Button Back
        {
            get { return _back; }
        }
    }
}
