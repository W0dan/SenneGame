using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Piratenkapitein : SchietendMonster
    {
        private int _life = 20;

        public Piratenkapitein()
            : base(new Size(20, 20), 5)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/Pirate.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 10, WaarBenIk.Y - 10, 20, 20));
        }

        public override void Beweeg()
        {
            var direction = Randomizer.Next(12);

            switch (direction)
            {
                case 0:
                case 1:
                    Beweeg_naar_rechts();
                    break;
                case 2:
                case 3:
                    Beweeg_naar_boven();
                    break;
                case 4:
                case 5:
                    Beweeg_naar_beneden();
                    break;
                case 6:
                case 7:
                    Beweeg_naar_links();
                    break;
                case 8:
                    Schiet_naar_boven();
                    break;
                case 9:
                    Schiet_naar_beneden();
                    break;
                case 10:
                    Schiet_naar_rechts();
                    break;
                case 11:
                    Schiet_naar_links();
                    break;
            }
        }

        public override void Ben_geraakt()
        {
            _life--;

            if (_life <= 0)
                Ben_dood = true;
        }
    }
}