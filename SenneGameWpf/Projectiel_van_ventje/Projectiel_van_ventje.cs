using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_ventje
{
    public class Projectiel_van_ventje : IProjectiel
    {
        protected Spel _spel;
        protected Point _locatie;
        protected bool _gestopt;
        private readonly Direction _direction;
        public bool Gestopt { get { return _gestopt; } }


        public Projectiel_van_ventje(Spel spel, Point startpunt, Direction direction)
        {
            _direction = direction;
            _spel = spel;
            _locatie = startpunt;
            _gestopt = false;
        }

        public void Stop()
        {
            _gestopt = true;
        }

        public void Beweeg()
        {
            if (_locatie.X > 1000 || _locatie.Y > 1000)
            {
                _gestopt = true;
                return;
            }
            if (_locatie.X < -1000 || _locatie.Y < -1000)
            {
                _gestopt = true;
                return;
            }

            var iets_geraakt = _spel.Is_er_iets_geraakt(NieuweLocatie(), Formaat);
            if (iets_geraakt == null || iets_geraakt.GetType() == typeof(Ventje))
                _locatie = NieuweLocatie();
            else
            {
                _gestopt = true;
            }
        }

        protected Point NieuweLocatie()
        {
            switch (_direction)
            {
                case Direction.Up:
                    return new Point(_locatie.X, _locatie.Y - 2);
                case Direction.Down:
                    return new Point(_locatie.X, _locatie.Y + 2);
                case Direction.Left:
                    return new Point(_locatie.X - 2, _locatie.Y);
                case Direction.Right:
                    return new Point(_locatie.X + 2, _locatie.Y);
            }

            return new Point();
        }

        private Size Formaat { get; set; }

        public Drawing Teken_jezelf()
        {
            ImageSource imageSource;
            ImageDrawing bulletDrawing;

            switch (_direction)
            {
                case Direction.Up:
                    imageSource = Resources.GetImage("SenneGameWpf", "images/projectiles/bullet_up.png");
                    Formaat = new Size(1, 3);
                    bulletDrawing = new ImageDrawing(imageSource, new Rect(_locatie.X, _locatie.Y - 3, 1, 3));
                    break;
                case Direction.Down:
                    imageSource = Resources.GetImage("SenneGameWpf", "images/projectiles/bullet_down.png");
                    Formaat = new Size(1, 3);
                    bulletDrawing = new ImageDrawing(imageSource, new Rect(_locatie.X, _locatie.Y, 1, 3));
                    break;
                case Direction.Left:
                    imageSource = Resources.GetImage("SenneGameWpf", "images/projectiles/bullet_left.png");
                    Formaat = new Size(3, 1);
                    bulletDrawing = new ImageDrawing(imageSource, new Rect(_locatie.X - 3, _locatie.Y, 3, 1));
                    break;
                case Direction.Right:
                    imageSource = Resources.GetImage("SenneGameWpf", "images/projectiles/bullet_right.png");
                    Formaat = new Size(3, 1);
                    bulletDrawing = new ImageDrawing(imageSource, new Rect(_locatie.X, _locatie.Y, 3, 1));
                    break;
                default:
                    bulletDrawing = null;
                    break;
            }

            return bulletDrawing;
        }
    }
}