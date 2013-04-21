using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_ventje
{
    public class ProjectielVanVentjeNaarRechts : Projectiel_van_ventje
    {
        public ProjectielVanVentjeNaarRechts(Spel spel, Point startpunt)
        {
            _spel = spel;
            _locatie = startpunt;
            _gestopt = false;
        }

        protected override Point NieuweLocatie()
        {
            var nieuwe_locatie = new Point(_locatie.X + 2, _locatie.Y);
            return nieuwe_locatie;
        }

        protected override Size Formaat
        {
            get { return new Size(3, 1); }
        }

        protected override LineGeometry Tekening
        {
            get { return new LineGeometry(new Point(_locatie.X - 1, _locatie.Y), new Point(_locatie.X + 1, _locatie.Y)); }
        }
    }
}