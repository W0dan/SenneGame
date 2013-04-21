using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Projectiel_van_monsterke
{
    public class ProjectielVanMonsterkeNaarBoven : Projectiel_van_monsterke
    {
        public ProjectielVanMonsterkeNaarBoven(ISpel spel, Point startpunt)
        {
            Spel = spel;
            Locatie = startpunt;
            _gestopt = false;
        }

        protected override Point NieuweLocatie()
        {
            var nieuwe_locatie = new Point(Locatie.X, Locatie.Y - 1);
            return nieuwe_locatie;
        }

        protected override Size Formaat
        {
            get { return new Size(1, 3); }
        }

        protected override LineGeometry Tekening
        {
            get { return new LineGeometry(new Point(Locatie.X, Locatie.Y - 1), new Point(Locatie.X, Locatie.Y + 1)); }
        }
    }
}