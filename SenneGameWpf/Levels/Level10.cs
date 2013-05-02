using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;

namespace SenneGameWpf.Levels
{
    public class Level10 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();
        private Hindernis _uitgang;

        public Level10(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            ZetVentje(spel);
        }

        private void MaakHindernissen()
        {
            for (var i = 105; i < 200; i += 10)
            {
                MaakHindernis(i, 5);
                MaakHindernis(i, 295);
                MaakHindernis(5, i);
                MaakHindernis(295, i);
            }

            for (var i = 15; i < 110; i += 10)
            {
                MaakHindernis(i, 105);
                MaakHindernis(i, 195);
                MaakHindernis(i + 180, 105);
                MaakHindernis(i + 180, 195);
            }

            for (var i = 15; i < 100; i += 10)
            {
                MaakHindernis(105, i);
                MaakHindernis(195, i);
            }

            for (var i = 215; i < 290; i += 10)
            {
                MaakHindernis(105, i);
                MaakHindernis(195, i);
            }

            _uitgang = MaakHindernis(105, 205);
            MaakHindernis(195, 205);
        }

        public Hindernis MaakHindernis(int x, int y)
        {
            var h = new Hindernis(x, y);
            _hindernissen.Add(h);
            return h;
        }

        public override Drawing Teken_jezelf()
        {
            var level = new DrawingGroup();

            level.Children.Add(DrawBackgroundPart(new Rect(100, 0, 100, 100)));
            level.Children.Add(DrawBackgroundPart(new Rect(0, 100, 100, 100)));
            level.Children.Add(DrawBackgroundPart(new Rect(100, 100, 100, 100)));
            level.Children.Add(DrawBackgroundPart(new Rect(200, 100, 100, 100)));
            level.Children.Add(DrawBackgroundPart(new Rect(100, 200, 100, 100)));

            level.Children.Add(Teken_monsterkes_en_hindernissen());

            return level;
        }

        private static Drawing DrawBackgroundPart(Rect r)
        {
            var rect = new RectangleGeometry(r);
            var backgroundPart = new GeometryDrawing(Brushes.Wheat, new Pen(Brushes.Wheat, 1), rect);
            return backgroundPart;
        }

        public override List<Hindernis> Hindernissen
        {
            get { return _hindernissen; }
        }

        public override Hindernis Uitgang
        {
            get { return _uitgang; }
        }

        public override Point Plek_waar_ventje_begint
        {
            get { return new Point(15, 150); }
        }
    }
}