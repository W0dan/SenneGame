using System.Globalization;
using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Projectiel_van_ventje;

namespace SenneGameWpf
{
    public class Ventje
    {
        private int _ammo = 1250; //minimum ammo to finish game appears to be 750
        private int _life = 3;
        private readonly Spel _spel;
        private readonly Size _hoe_groot_ben_ik;
        private Point _waar_ben_ik;
        private const int _speed = 5;

        public int Heb_timeout { get; set; }

        public Ventje(Spel spel, Point waar_ben_ik)
        {
            _spel = spel;
            _waar_ben_ik = waar_ben_ik;
            _hoe_groot_ben_ik = new Size(10, 10);
        }

        public Point Waar_zijt_ge
        {
            get { return _waar_ben_ik; }
        }

        public double Breedte { get { return _hoe_groot_ben_ik.Width; } }

        public double Hoogte { get { return _hoe_groot_ben_ik.Height; } }

        public Drawing Teken_jezelf()
        {
            var dg = new DrawingGroup();

            ImageSource imageSource;

            if (!(Heb_timeout > 0))
                imageSource = Resources.GetImage("SenneGameWpf", "images/smiley Angry.png");
            else
                imageSource = Resources.GetImage("SenneGameWpf", "images/smiley Angry_timeout.png");

            var ventje = new ImageDrawing(imageSource, new Rect(_waar_ben_ik.X - 5, _waar_ben_ik.Y - 5, 10, 10));

            dg.Children.Add(ventje);

            var levenImageSource = Resources.GetImage("SenneGameWpf", "images/smiley Angry.png");
            for (var i = 0; i < _life; i++)
            {
                var leven = new ImageDrawing(levenImageSource, new Rect(10 * i, -10, 10, 10));

                dg.Children.Add(leven);
            }

            var typeface = new Typeface("Arial");
            var ammo = new FormattedText(string.Format("AMMO: {0}", _ammo), CultureInfo.CurrentUICulture, FlowDirection.LeftToRight, typeface, 10, Brushes.Gray);
            var textgeometry = ammo.BuildGeometry(new Point(130, -10));
            var ammodrawing = new GeometryDrawing(Brushes.Gray, new Pen(Brushes.Gray, 0), textgeometry);
            dg.Children.Add(ammodrawing);

            return dg;
        }

        public void Beweeg_naar_boven()
        {
            Beweeg_naar(new Point(_waar_ben_ik.X, _waar_ben_ik.Y - _speed));
        }

        public void Beweeg_naar_beneden()
        {
            Beweeg_naar(new Point(_waar_ben_ik.X, _waar_ben_ik.Y + _speed));
        }

        public void Beweeg_naar_links()
        {
            Beweeg_naar(new Point(_waar_ben_ik.X - _speed, _waar_ben_ik.Y));
        }

        public void Beweeg_naar_rechts()
        {
            Beweeg_naar(new Point(_waar_ben_ik.X + _speed, _waar_ben_ik.Y));
        }

        private void Beweeg_naar(Point ik_wil_naar)
        {
            if (_spel.Is_er_een_hindernis_in_de_weg(ik_wil_naar, _hoe_groot_ben_ik))
                return;

            if (_spel.Is_er_een_monster_in_de_weg(ik_wil_naar, _hoe_groot_ben_ik))
            {
                Is_geraakt();
                return;
            }

            if (_spel.Is_hier_de_uitgang(ik_wil_naar, _hoe_groot_ben_ik))
            {
                _waar_ben_ik = ik_wil_naar;

                Level_uit();
                return;
            }

            _waar_ben_ik = ik_wil_naar;
        }

        public void Is_geraakt()
        {
            if (!(Heb_timeout > 0))
            {
                _life--;
                if (_life == 0)
                    _spel.GameOver();
                else
                    Heb_timeout = 20;
            }
        }

        private void Level_uit()
        {
            if (_life < 5)
                _life++;
            _spel.Win();
        }

        public IProjectiel Schiet_naar_boven()
        {
            if (_ammo <= 0)
                return null;

            _ammo -= 1;
            return new ProjectielVanVentjeNaarBoven(_spel, _waar_ben_ik);
        }

        public IProjectiel Schiet_naar_beneden()
        {
            if (_ammo <= 0)
                return null;

            _ammo -= 1;
            return new ProjectielVanVentjeNaarBeneden(_spel, _waar_ben_ik);
        }

        public IProjectiel Schiet_naar_links()
        {
            if (_ammo <= 0)
                return null;

            _ammo -= 1;
            return new ProjectielVanVentjeNaarLinks(_spel, _waar_ben_ik);
        }

        public IProjectiel Schiet_naar_rechts()
        {
            if (_ammo <= 0)
                return null;

            _ammo -= 1;
            return new ProjectielVanVentjeNaarRechts(_spel, _waar_ben_ik);
        }

        public void Ga_hier_staan(Point waar)
        {
            _waar_ben_ik = waar;
        }
    }
}