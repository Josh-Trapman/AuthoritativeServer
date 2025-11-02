using SplashKitSDK;

namespace Menus
{
    public class Button
    {
        private bool _visible;
        private int _width;
        private int _height;
        private string _text;
        private Point2D _position;
        private Rectangle _shape;

        public Button(float x, float y, int width, int height, string text)
        {
            _visible = true;
            _width = width;
            _height = height;
            _position = new Point2D() { X = x, Y = y };
            _text = text;

            _shape = new Rectangle() { X = x, Y = y, Width = width, Height = height};
        }

        public double X
        {
            get { return _position.X; }
        }
        public double Y
        {
            get { return _position.Y; }
        }

        public bool Visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public void Draw()
        {
            if (Hovering()) SplashKit.DrawRectangle(Color.Red, _shape);
            else SplashKit.FillRectangle(Color.Red, _shape);

            SplashKit.DrawText(_text, Color.Black, X + (_width - _text.Length * 10) / 2, Y + (_height / 2) - 5);
        }

        public bool Hovering()
        {
            Point2D mouse = SplashKit.MousePosition();

            bool hovered = mouse.X >= X && mouse.X <= X + _width &&
                            mouse.Y >= Y && mouse.Y <= Y + _height;

            return hovered;
        }

        public bool Clicked()
        {
            return SplashKit.MouseClicked(MouseButton.LeftButton) && Hovering();
        }
    }
}