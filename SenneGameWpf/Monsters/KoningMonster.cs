using System.Windows;
using System.Windows.Media;

namespace SenneGameWpf.Monsters
{
    public class KoningMonster:Monster
    {
        private int _levens = 70;

        public KoningMonster():base(new Size(50,50), 5)
        {
            
        }

        public override Drawing Teken_jezelf()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/Enemies/CartmanNinja.png");

            return new ImageDrawing(imageSource, new Rect(WaarBenIk.X - 25, WaarBenIk.Y - 25, 50, 50));
        }

        public override void Ben_geraakt()
        {
            _levens--;

            if (_levens < 1)
                Ben_dood = true;
        }
    }
}