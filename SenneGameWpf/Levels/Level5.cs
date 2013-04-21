using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;

namespace SenneGameWpf.Levels
{
    public class Level5 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level5(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddBigBlue(new Point(100, 40));
            AddBlue(new Point(40, 40));
            AddBigBlue(new Point(40, 100));
            AddBlue(new Point(40, 160));
            AddBigBlue(new Point(100, 160));
            AddBlue(new Point(160, 40));
            AddBigBlue(new Point(160, 100));
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

            _hindernissen.Add(new Hindernis(45, 25));
            _hindernissen.Add(new Hindernis(55, 35));
            _hindernissen.Add(new Hindernis(55, 45));
            _hindernissen.Add(new Hindernis(45, 55));
            _hindernissen.Add(new Hindernis(25, 45));
            _hindernissen.Add(new Hindernis(35, 55));

            _hindernissen.Add(new Hindernis(155, 25));
            _hindernissen.Add(new Hindernis(145, 35));
            _hindernissen.Add(new Hindernis(145, 45));
            _hindernissen.Add(new Hindernis(155, 55));
            _hindernissen.Add(new Hindernis(175, 45));
            _hindernissen.Add(new Hindernis(165, 55));

            _hindernissen.Add(new Hindernis(35, 145));
            _hindernissen.Add(new Hindernis(45, 145));
            _hindernissen.Add(new Hindernis(25, 155));
            _hindernissen.Add(new Hindernis(55, 155));
            _hindernissen.Add(new Hindernis(55, 165));
            _hindernissen.Add(new Hindernis(45, 175));

            _hindernissen.Add(new Hindernis(155, 145));
            _hindernissen.Add(new Hindernis(165, 145));
            _hindernissen.Add(new Hindernis(145, 155));
            _hindernissen.Add(new Hindernis(175, 155));
            _hindernissen.Add(new Hindernis(145, 165));
            _hindernissen.Add(new Hindernis(155, 175));
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