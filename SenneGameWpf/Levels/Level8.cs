using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;

namespace SenneGameWpf.Levels
{
    public class Level8 : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public Level8(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddTroll(new Point(40, 100));
            AddTroll(new Point(100, 40));
            AddTroll(new Point(160, 100));
            AddTroll(new Point(100, 160));

            AddTroll(new Point(160, 40));
            AddTroll(new Point(40, 160));
            AddTroll(new Point(160, 160));

            AddTitan(new Point(100, 100));
        }

        private void MaakHindernissen()
        {

            for (var x = 5; x < 200; x += 10)
            {
                AddTegel(x, 5);
                AddTegel(x, 195);
            }

            for (var y = 15; y < 180; y += 10)
            {
                AddTegel(5, y);
                AddTegel(195, y);
            }
            AddTegel(5, 185);

            _uitgang = AddTegel(195, 185);

            AddTegel(65, 15);
            AddTegel(65, 25);
            AddTegel(65, 35);
            AddTegel(135, 15);
            AddTegel(135, 25);
            AddTegel(135, 35);

            AddTegel(15, 65);
            AddTegel(25, 65);
            AddTegel(35, 65);
            AddTegel(15, 135);
            AddTegel(25, 135);
            AddTegel(35, 135);

            AddTegel(65, 185);
            AddTegel(65, 175);
            AddTegel(65, 165);
            AddTegel(135, 185);
            AddTegel(135, 175);
            AddTegel(135, 165);

            AddTegel(185, 65);
            AddTegel(175, 65);
            AddTegel(165, 65);
            AddTegel(185, 135);
            AddTegel(175, 135);
            AddTegel(165, 135);

            AddTegel(75, 75);
            AddTegel(125, 125);
            AddTegel(75, 125);
            AddTegel(125, 75);
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

            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    level.Children.Add(Teken_achtergrond(new Rect(i*66, j*66, 66, 66)));

            level.Children.Add(Teken_monsterkes_en_hindernissen());

            return level;
        }

        private static ImageDrawing Teken_achtergrond(Rect rect)
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/background-02.jpg");
            return new ImageDrawing(imageSource, rect);
        }
    }
}