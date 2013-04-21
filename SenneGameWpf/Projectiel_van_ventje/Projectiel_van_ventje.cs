using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_ventje
{
    public abstract class Projectiel_van_ventje : IProjectiel
    {
        protected Spel _spel;
        protected Point _locatie;
        protected bool _gestopt;
        public bool Gestopt { get { return _gestopt; } }

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

        protected abstract Point NieuweLocatie();

        protected abstract Size Formaat { get; }

        protected abstract LineGeometry Tekening { get; }

        public Drawing Teken_jezelf()
        {
            var lijnen = new GeometryGroup();

            lijnen.Children.Add(Tekening);

            var drawing = new GeometryDrawing
                {
                    Geometry = lijnen,
                    Pen = new Pen(Brushes.Black, 1),
                    Brush = Brushes.Black
                };

            return drawing;
        }
    }
}