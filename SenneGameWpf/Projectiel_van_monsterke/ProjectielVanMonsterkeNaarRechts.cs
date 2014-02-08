using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_monsterke
{
    public class ProjectielVanMonsterkeNaarRechts : Projectiel_van_monsterke
    {
        public ProjectielVanMonsterkeNaarRechts(ISpel spel, Point startpunt, Brush brush)
            : base(brush)
        {
            Spel = spel;
            Locatie = startpunt;
            _gestopt = false;
        }

        protected override Point NieuweLocatie()
        {
            var nieuwe_locatie = new Point(Locatie.X + 1, Locatie.Y);
            return nieuwe_locatie;
        }

        protected override Size Formaat
        {
            get { return new Size(3, 1); }
        }

        protected override LineGeometry Tekening
        {
            get { return new LineGeometry(new Point(Locatie.X - 1, Locatie.Y), new Point(Locatie.X + 1, Locatie.Y)); }
        }
    }
}