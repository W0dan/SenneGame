using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Gigant : Monster
    {
        private int _life = 20;

        public Gigant()
            : base(new Size(30, 30), 5)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/monster05.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 15, WaarBenIk.Y - 15, 30, 30));
        }

        public override void Ben_geraakt()
        {
            _life--;

            if (_life < 1)
                Ben_dood = true;
        }
    }
}