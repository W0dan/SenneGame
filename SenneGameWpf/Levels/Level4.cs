using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;

namespace SenneGameWpf.Levels
{
    public class Level4 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level4(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddGigant(new Point(100, 100));
            AddBlue(new Point(40, 40));
            AddBlue(new Point(40, 160));
            AddBlue(new Point(160, 40));
            AddBlue(new Point(160, 160));
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 200; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 5));
                _hindernissen.Add(new Hindernis(x, 195));
            }

            for (var y = 25; y < 190; y += 10)
            {
                _hindernissen.Add(new Hindernis(5, y));
                _hindernissen.Add(new Hindernis(195, y));
            }
            _hindernissen.Add(new Hindernis(5, 15));

            _uitgang = new Hindernis(195, 15);
            _hindernissen.Add(_uitgang);

            _hindernissen.Add(new Hindernis(70, 40));
            _hindernissen.Add(new Hindernis(80, 40));
            _hindernissen.Add(new Hindernis(90, 40));

            _hindernissen.Add(new Hindernis(110, 40));
            _hindernissen.Add(new Hindernis(120, 40));
            _hindernissen.Add(new Hindernis(130, 40));

            _hindernissen.Add(new Hindernis(70, 160));
            _hindernissen.Add(new Hindernis(80, 160));
            _hindernissen.Add(new Hindernis(90, 160));

            _hindernissen.Add(new Hindernis(110, 160));
            _hindernissen.Add(new Hindernis(120, 160));
            _hindernissen.Add(new Hindernis(130, 160));

            _hindernissen.Add(new Hindernis(40, 70));
            _hindernissen.Add(new Hindernis(40, 80));
            _hindernissen.Add(new Hindernis(40, 90));

            _hindernissen.Add(new Hindernis(40, 110));
            _hindernissen.Add(new Hindernis(40, 120));
            _hindernissen.Add(new Hindernis(40, 130));

            _hindernissen.Add(new Hindernis(160, 70));
            _hindernissen.Add(new Hindernis(160, 80));
            _hindernissen.Add(new Hindernis(160, 90));

            _hindernissen.Add(new Hindernis(160, 110));
            _hindernissen.Add(new Hindernis(160, 120));
            _hindernissen.Add(new Hindernis(160, 130));

            _hindernissen.Add(new Hindernis(60, 60));
            _hindernissen.Add(new Hindernis(60, 100));
            _hindernissen.Add(new Hindernis(60, 140));
            _hindernissen.Add(new Hindernis(100, 60));
            _hindernissen.Add(new Hindernis(100, 140));
            _hindernissen.Add(new Hindernis(140, 140));
            _hindernissen.Add(new Hindernis(140, 100));
            _hindernissen.Add(new Hindernis(140, 60));
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
            get { return new Point(15, 15); }
        }

        public override Drawing Teken_jezelf()
        {
            var level = new DrawingGroup();

            level.Children.Add(Teken_achtergrond());
            level.Children.Add(Teken_monsterkes_en_hindernissen());

            return level;
        }

        private static ImageDrawing Teken_achtergrond()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/background-01.jpg");
            return new ImageDrawing(imageSource, new Rect(0, 0, 200, 200));
        }
    }
}