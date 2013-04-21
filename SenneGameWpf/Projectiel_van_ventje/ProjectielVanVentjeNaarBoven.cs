using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_ventje
{
    public class ProjectielVanVentjeNaarBoven : Projectiel_van_ventje
    {
        public ProjectielVanVentjeNaarBoven(Spel spel, Point startpunt)
        {
            _spel = spel;
            _locatie = startpunt;
            _gestopt = false;
        }

        protected override Point NieuweLocatie()
        {
            var nieuwe_locatie = new Point(_locatie.X, _locatie.Y - 2);
            return nieuwe_locatie;
        }

        protected override Size Formaat
        {
            get { return new Size(1, 3); }
        }

        protected override LineGeometry Tekening
        {
            get { return new LineGeometry(new Point(_locatie.X, _locatie.Y - 1), new Point(_locatie.X, _locatie.Y + 1)); }
        }
    }
}