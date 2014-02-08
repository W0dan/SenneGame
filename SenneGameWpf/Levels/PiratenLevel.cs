using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class PiratenLevel : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public PiratenLevel(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Piraat>(new Point(40, 100));
            AddMonster<Piraat>(new Point(100, 40));
            AddMonster<Piraat>(new Point(160, 100));
            AddMonster<Piraat>(new Point(100, 160));
            AddMonster<Piratenkapitein>(new Point(100, 100));
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

            AddTegel(65, 175);
            AddTegel(65, 165);

            AddTegel(25, 135);
            AddTegel(35, 135);
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
                return new Point(15, 185);
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