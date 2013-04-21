using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Hindernissen
{
    public class Hindernis
    {
        private Point _locatie;

        public Hindernis(double x, double y)
        {
            _locatie = new Point(x, y);
        }

        public double X { get { return _locatie.X; } }
        public double Y { get { return _locatie.Y; } }

        public virtual Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/brick_wall.jpg");

            return  new ImageDrawing(imageSource, new Rect(X - 5, Y - 5, 10, 10));
        }
    }
}