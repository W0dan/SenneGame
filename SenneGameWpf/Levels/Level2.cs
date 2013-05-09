using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class Level2 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level2(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Zombie>(new Point(85, 85));
            AddMonster<Zombie>(new Point(85, 115));
            AddMonster<Zombie>(new Point(115, 85));
            AddMonster<Zombie>(new Point(115, 115));
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

            _hindernissen.Add(new Hindernis(95, 65));
            _hindernissen.Add(new Hindernis(95, 75));
            _hindernissen.Add(new Hindernis(95, 85));
            _hindernissen.Add(new Hindernis(95, 95));
            _hindernissen.Add(new Hindernis(95, 105));
            _hindernissen.Add(new Hindernis(95, 115));
            _hindernissen.Add(new Hindernis(95, 125));
            _hindernissen.Add(new Hindernis(95, 135));
            _hindernissen.Add(new Hindernis(95, 145));

            _hindernissen.Add(new Hindernis(55, 105));
            _hindernissen.Add(new Hindernis(65, 105));
            _hindernissen.Add(new Hindernis(75, 105));
            _hindernissen.Add(new Hindernis(85, 105));
            _hindernissen.Add(new Hindernis(95, 105));
            _hindernissen.Add(new Hindernis(105, 105));
            _hindernissen.Add(new Hindernis(115, 105));
            _hindernissen.Add(new Hindernis(125, 105));
            _hindernissen.Add(new Hindernis(135, 105));
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