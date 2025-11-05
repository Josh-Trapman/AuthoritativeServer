using SplashKitSDK;

namespace Menus
{
    public class Button
    {
        protected int _width;
        protected int _height;
        protected string _text;
        protected Point2D _position;
        protected Rectangle _shape;

        public Button(float x, float y, int width, int height)
        {
            _text = "";
            _width = width;
            _height = height;
            _position = new Point2D() { X = x, Y = y };  

            _shape = new Rectangle() { X = x, Y = y, Width = width, Height = height};
        }

        public Button(float x, float y, int width, int height, string text)
        {
            _width = width;
            _height = height;
            _position = new Point2D() { X = x, Y = y };
            _text = text;

            _shape = new Rectangle() { X = x, Y = y, Width = width, Height = height};
        }

        public double X
        {
            get { return _position.X; }
            set { _position.X = value; }
        }
        public double Y
        {
            get { return _position.Y; }
            set { _position.Y = value; }
        }

        public virtual void Draw()
        {
            _shape.X = X;
            _shape.Y = Y;

            if (Hovering()) SplashKit.DrawRectangle(Color.Red, _shape);
            else SplashKit.FillRectangle(Color.Red, _shape);

            SplashKit.DrawText(_text, Color.Black, X + (_width - _text.Length * 10) / 2, Y + (_height / 2) - 5);
        }

        public virtual bool Hovering()
        {
            Point2D mouse = SplashKit.MousePosition();

            bool hovered = mouse.X >= X && mouse.X <= X + _width &&
                            mouse.Y >= Y && mouse.Y <= Y + _height;

            return hovered;
        }

        public virtual bool Clicked()
        {
            return SplashKit.MouseClicked(MouseButton.LeftButton) && Hovering();
        }
    }
}