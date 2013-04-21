using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;

namespace SenneGameWpf.Levels
{
    public class Level3 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level3(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddHeks(new Point(40, 40));
            AddHeks(new Point(160, 160));
            AddHeks(new Point(160, 40));
            AddHeks(new Point(40, 160));

            AddHeks(new Point(60, 60));
            AddHeks(new Point(140, 140));
            AddHeks(new Point(140, 60));
            AddHeks(new Point(60, 140));
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

            for (var x = 15; x < 180; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 55));
                _hindernissen.Add(new Hindernis(x, 95));
                _hindernissen.Add(new Hindernis(x, 135));
                _hindernissen.Add(new Hindernis(x, 175));
            }

            for (var x = 25; x < 190; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 35));
                _hindernissen.Add(new Hindernis(x, 75));
                _hindernissen.Add(new Hindernis(x, 115));
                _hindernissen.Add(new Hindernis(x, 155));
            }

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
            get { return new Point(15, 185); }
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