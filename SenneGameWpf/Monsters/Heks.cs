using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Heks : Monster
    {
        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/Witch.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 5, WaarBenIk.Y - 5, 10, 10));
        }

        public override void Ben_geraakt()
        {
            Ben_dood = true;
        }
    }
}