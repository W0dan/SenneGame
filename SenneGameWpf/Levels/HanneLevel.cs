using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Hindernissen;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class HanneLevel : Level
    {
        private readonly List<Hindernis> _hindernissen = new List<Hindernis>();

        private Hindernis _uitgang;

        public HanneLevel(ISpel spel)
            : base(spel)
        {
            MaakHindernissen();
            MaakMonsterkes();
            ZetVentje(spel);
        }

        private void MaakMonsterkes()
        {
            AddMonster<Titan>(50, 150);
            AddMonster<FastBlue>(185, 45);
            AddMonster<Cyclops>(255, 95);
            AddMonster<Piraat>(325, 135);
            AddMonster<BigBlue>(350, 40);
            AddMonster<BigBlue>(340, 110);
        }

        private Hindernis AddHindernis(int x, int y)
        {
            var hindernis = new Hindernis(x, y);
            _hindernissen.Add(hindernis);
            return hindernis;
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 400; x += 10)
            {
                AddHindernis(x, 5);
                AddHindernis(x, 195);
            }

            for (var y = 15; y < 180; y += 10)
            {
                AddHindernis(5, y);
                AddHindernis(395, y);
            }
            AddHindernis(5, 185);

            _uitgang = AddHindernis(395, 185);

            AddHindernis(25, 165);
            AddHindernis(35, 175);

            AddHindernis(45, 25);
            AddHindernis(45, 35);
            AddHindernis(45, 45);
            AddHindernis(55, 25);
            AddHindernis(55, 35);
            AddHindernis(55, 45);

            AddHindernis(125, 35);
            AddHindernis(135, 35);
            AddHindernis(145, 35);
            AddHindernis(155, 35);
            AddHindernis(125, 45);
            AddHindernis(125, 55);
            AddHindernis(125, 65);
            AddHindernis(135, 65);
            AddHindernis(145, 65);
            AddHindernis(155, 65);

            AddHindernis(205, 95);
            AddHindernis(215, 95);
            AddHindernis(205, 105);
            AddHindernis(215, 105);

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