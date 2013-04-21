using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Vampire : Monster
    {
        private int _life = 15;

        public Vampire(ISpel spel, Point waar_ben_ik)
            : base(spel, waar_ben_ik)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/Vampire.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 5, WaarBenIk.Y - 5, 10, 10));
        }

        public override void Ben_geraakt()
        {
            _life--;

            if (_life < 1)
                Ben_dood = true;
        }
    }
}