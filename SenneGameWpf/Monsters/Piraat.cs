using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Piraat : SchietendMonster
    {
        public Piraat(ISpel spel, Point waar_ben_ik)
            : base(spel, waar_ben_ik)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/Pirate.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 5, WaarBenIk.Y - 5, 10, 10));
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
            Ben_dood = true;
        }
    }
}