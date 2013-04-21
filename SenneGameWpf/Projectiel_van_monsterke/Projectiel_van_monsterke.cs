using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_monsterke
{
    public abstract class Projectiel_van_monsterke : IProjectiel
    {
        protected ISpel Spel;
        protected Point Locatie;
        protected bool _gestopt;
        public bool Gestopt { get { return _gestopt; } }

        public void Stop()
        {
            _gestopt = true;
        }

        public void Beweeg()
        {
            if (Locatie.X > 1000 || Locatie.Y > 1000)
            {
                _gestopt = true;
                return;
            }
            if (Locatie.X < -1000 || Locatie.Y < -1000)
            {
                _gestopt = true;
                return;
            }

            if (Spel.Is_er_een_hindernis_in_de_weg(NieuweLocatie(), Formaat))
            {
                _gestopt = true;
                return;
            }

            var ventje_geraakt = Spel.Is_hier_het_ventje(NieuweLocatie(), Formaat);
            if (ventje_geraakt)
            {
                _gestopt = true;
                Spel.Ventje_is_geraakt();
            }
            else
            {
                Locatie = NieuweLocatie();
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
                    Pen = new Pen(Brushes.Red, 1),
                    Brush = Brushes.Red
                };

            return drawing;
        }
    }
}