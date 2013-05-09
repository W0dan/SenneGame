using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class Level6 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level6(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Zombie>(new Point(40, 40));
            AddMonster<Zombie>(new Point(40, 160));
            AddMonster<Zombie>(new Point(160, 40));
            AddMonster<Zombie>(new Point(160, 160));
            AddMonster<Zombie>(new Point(240, 40));
            AddMonster<Zombie>(new Point(240, 160));
            AddMonster<Zombie>(new Point(360, 40));
            AddMonster<Zombie>(new Point(360, 160));

            AddMonster<Gigant>(new Point(100, 100));
            AddMonster<Gigant>(new Point(200, 100));
            AddMonster<Gigant>(new Point(300, 100));
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

            _hindernissen.Add(new Hindernis(45, 25));
            _hindernissen.Add(new Hindernis(55, 35));
            _hindernissen.Add(new Hindernis(55, 45));
            _hindernissen.Add(new Hindernis(45, 55));
            _hindernissen.Add(new Hindernis(25, 45));
            _hindernissen.Add(new Hindernis(35, 55));
            _hindernissen.Add(new Hindernis(355, 25));
            _hindernissen.Add(new Hindernis(345, 35));
            _hindernissen.Add(new Hindernis(345, 45));
            _hindernissen.Add(new Hindernis(355, 55));
            _hindernissen.Add(new Hindernis(375, 45));
            _hindernissen.Add(new Hindernis(365, 55));

            _hindernissen.Add(new Hindernis(155, 25));
            _hindernissen.Add(new Hindernis(145, 35));
            _hindernissen.Add(new Hindernis(145, 45));
            _hindernissen.Add(new Hindernis(155, 55));
            _hindernissen.Add(new Hindernis(175, 45));
            _hindernissen.Add(new Hindernis(165, 55));
            _hindernissen.Add(new Hindernis(155, 145));
            _hindernissen.Add(new Hindernis(165, 145));
            _hindernissen.Add(new Hindernis(145, 155));
            _hindernissen.Add(new Hindernis(175, 155));
            _hindernissen.Add(new Hindernis(145, 165));
            _hindernissen.Add(new Hindernis(155, 175));

            _hindernissen.Add(new Hindernis(245, 25));
            _hindernissen.Add(new Hindernis(255, 35));
            _hindernissen.Add(new Hindernis(255, 45));
            _hindernissen.Add(new Hindernis(245, 55));
            _hindernissen.Add(new Hindernis(225, 45));
            _hindernissen.Add(new Hindernis(235, 55));
            _hindernissen.Add(new Hindernis(235, 145));
            _hindernissen.Add(new Hindernis(245, 145));
            _hindernissen.Add(new Hindernis(225, 155));
            _hindernissen.Add(new Hindernis(255, 155));
            _hindernissen.Add(new Hindernis(255, 165));
            _hindernissen.Add(new Hindernis(245, 175));

            _hindernissen.Add(new Hindernis(35, 145));
            _hindernissen.Add(new Hindernis(45, 145));
            _hindernissen.Add(new Hindernis(25, 155));
            _hindernissen.Add(new Hindernis(55, 155));
            _hindernissen.Add(new Hindernis(55, 165));
            _hindernissen.Add(new Hindernis(45, 175));
            _hindernissen.Add(new Hindernis(355, 145));
            _hindernissen.Add(new Hindernis(365, 145));
            _hindernissen.Add(new Hindernis(345, 155));
            _hindernissen.Add(new Hindernis(375, 155));
            _hindernissen.Add(new Hindernis(345, 165));
            _hindernissen.Add(new Hindernis(355, 175));
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