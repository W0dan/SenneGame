using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class GroteHeks : SchietendMonster
    {
        private int _levens = 10;

        public GroteHeks()
            : base(new Size(30, 30), 5, Brushes.Green)
        {

        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/Witch.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 15, WaarBenIk.Y - 15, 30, 30));
        }

        public override void Beweeg()
        {
            var direction = Randomizer.Next(14);

            switch (direction)
            {
                case 0:
                case 1:
                case 2:
                    Beweeg_naar_rechts();
                    break;
                case 3:
                case 4:
                case 5:
                    Beweeg_naar_boven();
                    break;
                case 6:
                case 7:
                case 8:
                    Beweeg_naar_beneden();
                    break;
                case 9:
                case 10:
                case 11:
                    Beweeg_naar_links();
                    break;
                case 12:
                    Schiet_naar_rechts();
                    break;
                case 13:
                    Schiet_naar_links();
                    break;
            }
        }

        public override void Ben_geraakt()
        {
            _levens--;

            if (_levens <= 0)
                Ben_dood = true;
        }
    }
}