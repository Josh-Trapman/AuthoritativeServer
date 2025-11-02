namespace Menus
{
    public interface IMenu
    {
        public bool Visible { get; set; }

        public void Draw();

    }
}