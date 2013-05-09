using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Titan : Monster
    {
        private int _life = 50;

        public Titan()
            : base(new Size(40, 40), 5)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/monster05.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 20, WaarBenIk.Y - 20, 40, 40));
        }

        public override void Ben_geraakt()
        {
            _life--;

            if (_life < 1)
                Ben_dood = true;
        }
    }
}