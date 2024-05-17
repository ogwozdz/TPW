using System.ComponentModel;
using System.Drawing;

namespace Dane
{
    public class Ball : INotifyPropertyChanged
    {
        private double _x;
        private double _y;

        public double X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    NotifyPropertyChanged(nameof(X));
                }
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    NotifyPropertyChanged(nameof(Y));
                }
            }
        }

        public double VelocityX { get; set; }
        public double VelocityY { get; set; }

        private Rectangle collisionRect;
        public Rectangle CollisionRect => collisionRect;

        public double Mass = 5.0;

        private void UpdateRect()
        {
            collisionRect.X = (int)Math.Round(X);
            collisionRect.Y = (int)Math.Round(Y);
        }
        public Ball()
        {
            collisionRect = new Rectangle((int)Math.Round(X), (int)Math.Round(Y), 76, 76);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
