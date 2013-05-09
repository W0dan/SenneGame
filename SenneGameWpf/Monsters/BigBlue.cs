using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class BigBlue : Monster
    {
        private int _life = 5;

        public BigBlue()
            : base(new Size(20, 20), 5)
        {

        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/monster.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 10, WaarBenIk.Y - 10, 20, 20));
        }

        public override void Ben_geraakt()
        {
            _life--;

            if (_life < 1)
                Ben_dood = true;
        }
    }
}