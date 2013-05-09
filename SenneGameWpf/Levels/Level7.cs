using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class Level7 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level7(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Zombie>(new Point(45, 45));
            AddMonster<Zombie>(new Point(85, 45));
            AddMonster<Zombie>(new Point(125, 45));
            AddMonster<Zombie>(new Point(165, 45));
            AddMonster<Zombie>(new Point(205, 45));
            AddMonster<Zombie>(new Point(245, 45));
            AddMonster<Zombie>(new Point(285, 45));
            AddMonster<Zombie>(new Point(325, 45));
            AddMonster<Zombie>(new Point(365, 45));

            AddMonster<Zombie>(new Point(45, 155));
            AddMonster<Zombie>(new Point(85, 155));
            AddMonster<Zombie>(new Point(125, 155));
            AddMonster<Zombie>(new Point(165, 155));
            AddMonster<Zombie>(new Point(205, 155));
            AddMonster<Zombie>(new Point(245, 155));
            AddMonster<Zombie>(new Point(285, 155));
            AddMonster<Zombie>(new Point(325, 155));
            AddMonster<Zombie>(new Point(365, 155));

            AddMonster<Vampire>(new Point(100, 100));
            AddMonster<Vampire>(new Point(200, 100));
            AddMonster<Vampire>(new Point(300, 100));

            AddMonster<Weerwolf>(new Point(50, 100));
            AddMonster<Weerwolf>(new Point(150, 100));
            AddMonster<Weerwolf>(new Point(250, 100));
            AddMonster<Weerwolf>(new Point(350, 100));
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 400; x += 10)
            {
                _hindernissen.Add(new Hindernis(x, 5));
                _hindernissen.Add(new Hindernis(x, 195));
            }

            for (var y = 15; y < 180; y += 10)
            {
                _hindernissen.Add(new Hindernis(5, y));
                _hindernissen.Add(new Hindernis(395, y));
            }
            _hindernissen.Add(new Hindernis(395, 185));

            _uitgang = new Hindernis(5, 185);
            _hindernissen.Add(_uitgang);

            Maak_graf_1(new Point(35, 35));
            Maak_graf_1(new Point(75, 35));
            Maak_graf_1(new Point(115, 35));
            Maak_graf_1(new Point(155, 35));
            Maak_graf_1(new Point(195, 35));
            Maak_graf_1(new Point(235, 35));
            Maak_graf_1(new Point(275, 35));
            Maak_graf_1(new Point(315, 35));
            Maak_graf_1(new Point(355, 35));

            Maak_graf_2(new Point(35, 165));
            Maak_graf_2(new Point(75, 165));
            Maak_graf_2(new Point(115, 165));
            Maak_graf_2(new Point(155, 165));
            Maak_graf_2(new Point(195, 165));
            Maak_graf_2(new Point(235, 165));
            Maak_graf_2(new Point(275, 165));
            Maak_graf_2(new Point(315, 165));
            Maak_graf_2(new Point(355, 165));

        }

        private void Maak_graf_1(Point locatie)
        {
            var x = locatie.X;
            var y = locatie.Y;

            _hindernissen.Add(new Hindernis(x, y));
            _hindernissen.Add(new Hindernis(x + 10, y));
            _hindernissen.Add(new Hindernis(x + 20, y));
            _hindernissen.Add(new Hindernis(x, y + 10));
            _hindernissen.Add(new Hindernis(x + 20, y + 10));
            _hindernissen.Add(new Hindernis(x, y + 20));
            _hindernissen.Add(new Hindernis(x + 20, y + 20));
        }

        private void Maak_graf_2(Point locatie)
        {
            var x = locatie.X;
            var y = locatie.Y;

            _hindernissen.Add(new Hindernis(x, y));
            _hindernissen.Add(new Hindernis(x + 10, y));
            _hindernissen.Add(new Hindernis(x + 20, y));
            _hindernissen.Add(new Hindernis(x, y - 10));
            _hindernissen.Add(new Hindernis(x + 20, y - 10));
            _hindernissen.Add(new Hindernis(x, y - 20));
            _hindernissen.Add(new Hindernis(x + 20, y - 20));
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
            get { return new Point(385, 185); }
        }

        public override Drawing Teken_jezelf()
        {
            var level = new DrawingGroup();

            level.Children.Add(Teken_achtergrond(new Rect(0, 0, 200, 200)));
            level.Children.Add(Teken_achtergrond(new Rect(200, 0, 200, 200)));
            level.Children.Add(Teken_monsterkes_en_hindernissen());

            return level;
        }

        private static ImageDrawing Teken_achtergrond(Rect rect)
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/background-01.jpg");
            return new ImageDrawing(imageSource, rect);
        }
    }
}