using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class Level1 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level1(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Heks>(new Point(40, 100));
            AddMonster<Heks>(new Point(100, 40));
            AddMonster<Heks>(new Point(160, 100));
            AddMonster<Heks>(new Point(100, 160));
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 200; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 5));
                _hindernissen.Add(new Hindernis(x, 195));
            }

            for (var y = 15; y < 180; y += 10)
            {
                _hindernissen.Add(new Hindernis(5, y));
                _hindernissen.Add(new Hindernis(195, y));
            }
            _hindernissen.Add(new Hindernis(5, 185));

            _uitgang = new Hindernis(195, 185);
            _hindernissen.Add(_uitgang);

            _hindernissen.Add(new Hindernis(95, 95));
            _hindernissen.Add(new Hindernis(95, 105));
            _hindernissen.Add(new Hindernis(105, 95));
            _hindernissen.Add(new Hindernis(105, 105));
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
            get
            {
                return new Point(20, 20);
            }
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