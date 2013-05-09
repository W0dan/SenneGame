using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class Cyclops : Monster
    {
        private int _life = 40;

        public Cyclops()
            : base(new Size(30, 30), 5)
        {
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/monster01.png");

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