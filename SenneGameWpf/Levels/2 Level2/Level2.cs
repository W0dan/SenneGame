using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels.Level2
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
            MaakVerborgenKamers();
        }

        private void MaakVerborgenKamers()
        {
            var verborgenKamer1 = new VerborgenKamer1(this, new Point(50, -100), new Size(100, 100));
            AddVerborgenKamer(verborgenKamer1, new Point(95, 5));

            var verborgenKamer2 = new VerborgenKamer2(this, new Point(200, 50), new Size(100, 100));
            AddVerborgenKamer(verborgenKamer2, new Point(195, 95));

            var verborgenKamer3 = new VerborgenKamer3(this, new Point(50, 200), new Size(100, 100));
            AddVerborgenKamer(verborgenKamer3, new Point(115, 195));
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
            MaakMuurBovenkant();
            MaakMuurOnderkant();
            MaakMuurLinks();
            MaakMuurRechts();

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

        private void MaakMuurRechts()
        {
            for (var y = 15; y < 95; y += 10)
            {
                _hindernissen.Add(new Hindernis(195, y));
            }

            for (var y = 105; y < 180; y += 10)
            {
                _hindernissen.Add(new Hindernis(195, y));
            }

            _uitgang = new Hindernis(195, 185);
            _hindernissen.Add(_uitgang);
        }

        private void MaakMuurLinks()
        {
            for (var y = 15; y < 200; y += 10)
            {
                _hindernissen.Add(new Hindernis(5, y));
            }
        }

        private void MaakMuurOnderkant()
        {
            for (var x = 5; x < 115; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 195));
            }
            for (var x = 125; x < 200; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 195));
            }
        }

        private void MaakMuurBovenkant()
        {
            for (var x = 5; x < 95; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 5));
            }
            for (var x = 105; x < 200; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 5));
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

            foreach (var verborgenKamer in VerborgenKamers)
            {
                level.Children.Add(verborgenKamer.Teken_jezelf());
            }

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