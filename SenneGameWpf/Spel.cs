using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using SenneGameWpf.Levels;
using SenneGameWpf.Monsters;

namespace SenneGameWpf
{
    public class Spel : ISpel
    {
        private Ventje _ventje;
        private Level _level;

        private bool _is_gameOver;
        private bool _is_gewonnen;
        private readonly List<IProjectiel> _projectielen = new List<IProjectiel>();

        private readonly DispatcherTimer _projectiel_timer;

        public int _ventje_heeft_timeout
        {
            get { return _ventje.Heb_timeout; }
            set { _ventje.Heb_timeout = value; }
        }

        public Spel()
        {
            _projectiel_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 5) };
            _projectiel_timer.Tick += ProjectielTimerElapsed;
        }
        private void ProjectielTimerElapsed(object sender, EventArgs e)
        {
            var gestopteProjectielen = new List<IProjectiel>();

            foreach (var projectiel in _projectielen)
            {
                projectiel.Beweeg();
                if (projectiel.Gestopt)
                {
                    gestopteProjectielen.Add(projectiel);
                }
            }

            foreach (var projectiel in gestopteProjectielen)
            {
                _projectielen.Remove(projectiel);
            }

            if (Level_is_gedaan)
            {
                foreach (var projectiel in _projectielen)
                {
                    projectiel.Stop();
                }
            }
        }

        public bool Level_is_gedaan
        {
            get
            {
                return _is_gameOver || _is_gewonnen;
            }
        }

        public Level Level
        {
            get { return _level; }
            set
            {
                _level = value;
                _is_gameOver = false;
                _is_gewonnen = false;
            }
        }

        public bool Is_er_een_hindernis_in_de_weg(Point plek, Size grootte)
        {
            foreach (var hindernis in _level.Hindernissen)
            {
                if (Math.Abs(plek.X - hindernis.X) < (5 + grootte.Width / 2)
                    && Math.Abs(plek.Y - hindernis.Y) < Math.Abs(5 + grootte.Height / 2))
                    return true;
            }

            return false;
        }

        public bool Is_er_een_monster_in_de_weg(Point plek, Size grootte)
        {
            foreach (var monsterke in _level.Monsterkes)
            {
                if (Math.Abs(plek.X - monsterke.Waar_zijt_ge.X) < (monsterke.Breedte / 2 + grootte.Width / 2)
                    && Math.Abs(plek.Y - monsterke.Waar_zijt_ge.Y) < Math.Abs(monsterke.Hoogte / 2 + grootte.Height / 2)
                    && !monsterke.Is_dood)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Is_er_een_monster_in_de_weg(Point plek, Size grootte, Monster ikke)
        {
            foreach (var monsterke in _level.Monsterkes)
            {
                if (monsterke == ikke)
                    continue;

                if (Math.Abs(plek.X - monsterke.Waar_zijt_ge.X) < (monsterke.Breedte / 2 + grootte.Width / 2)
                    && Math.Abs(plek.Y - monsterke.Waar_zijt_ge.Y) < Math.Abs(monsterke.Hoogte / 2 + grootte.Height / 2)
                    && !monsterke.Is_dood)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Is_hier_de_uitgang(Point plek, Size grootte)
        {
            if (Math.Abs(plek.X - _level.Uitgang.X) < (5 + grootte.Width / 2)
                && Math.Abs(plek.Y - _level.Uitgang.Y) < Math.Abs(5 + grootte.Height / 2))
            {
                return true;
            }
            return false;
        }

        public bool Is_hier_het_ventje(Point plek, Size grootte)
        {
            if (Math.Abs(plek.X - _ventje.Waar_zijt_ge.X) < (_ventje.Breedte / 2 + grootte.Width / 2)
                && Math.Abs(plek.Y - _ventje.Waar_zijt_ge.Y) < Math.Abs(_ventje.Hoogte / 2 + grootte.Height / 2))
            {
                return true;
            }
            return false;
        }

        public object Is_er_iets_geraakt(Point plek, Size grootte)
        {
            if (Is_er_een_hindernis_in_de_weg(plek, grootte))
                return Plek_is_bezet_door.Hindernis;

            if (Math.Abs(plek.X - _ventje.Waar_zijt_ge.X) < (_ventje.Breedte / 2 + grootte.Width / 2)
                && Math.Abs(plek.Y - _ventje.Waar_zijt_ge.Y) < Math.Abs(_ventje.Hoogte / 2 + grootte.Height / 2))
                return _ventje;

            foreach (var monsterke in _level.Monsterkes)
            {
                if (Math.Abs(plek.X - monsterke.Waar_zijt_ge.X) < (monsterke.Breedte / 2 + grootte.Width / 2)
                    && Math.Abs(plek.Y - monsterke.Waar_zijt_ge.Y) < Math.Abs(monsterke.Hoogte / 2 + grootte.Height / 2)
                    && !monsterke.Is_dood)
                {
                    monsterke.Ben_geraakt();
                    if (_level.Monsterkes.All(x => x.Is_dood))
                    {
                        _level.Hindernissen.Remove(_level.Uitgang);
                    }
                    return monsterke;
                }
            }

            return null;
        }

        public Drawing Teken_jezelf()
        {
            var speelveld = new DrawingGroup();

            speelveld.Children.Add(_level.Teken_jezelf());

            speelveld.Children.Add(_ventje.Teken_jezelf());

            foreach (var projectiel in _projectielen)
            {
                speelveld.Children.Add(projectiel.Teken_jezelf());
            }

            return speelveld;
        }

        public Drawing Teken_gewonnen()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/win.jpg");
            var gewonnen = new ImageDrawing(imageSource, new Rect(0, 0, 1000, 667));

            var speelveld = new DrawingGroup();
            speelveld.Children.Add(gewonnen);
            return speelveld;
        }

        public bool Is_gameover { get { return _is_gameOver; } }
        public bool Is_gewonnen { get { return _is_gewonnen; } }

        public Drawing Teken_gameOver()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/gameover2.jpg");
            var gameover = new ImageDrawing(imageSource, new Rect(0, 0, 600, 270));

            var speelveld = new DrawingGroup();
            speelveld.Children.Add(gameover);
            return speelveld;
        }

        public Drawing Teken_probeer_opnieuw()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/tryagain.jpg");
            var gameover = new ImageDrawing(imageSource, new Rect(0, 0, 617, 775));

            var speelveld = new DrawingGroup();
            speelveld.Children.Add(gameover);
            return speelveld;
        }

        public Ventje Zet_ventje(Point point)
        {
            if (_ventje == null)
                _ventje = new Ventje(this, point);
            else
            {
                _ventje.Ga_hier_staan(point);
            }
            return _ventje;
        }

        public void Ventje_is_geraakt()
        {
            _ventje.Is_geraakt();
        }

        public void GameOver()
        {
            _is_gameOver = true;
            _projectiel_timer.Stop();
        }

        public void Win()
        {
            _is_gewonnen = true;
        }

        public void Ventje_schiet_naar_boven()
        {
            _projectielen.Add(_level.Ventje.Schiet_naar_boven());
        }

        public void Ventje_schiet_naar_beneden()
        {
            _projectielen.Add(_level.Ventje.Schiet_naar_beneden());
        }

        public void Ventje_schiet_naar_links()
        {
            _projectielen.Add(_level.Ventje.Schiet_naar_links());
        }

        public void Ventje_schiet_naar_rechts()
        {
            _projectielen.Add(_level.Ventje.Schiet_naar_rechts());
        }

        public void Monsterke_schiet(IProjectiel projectiel)
        {
            _projectielen.Add(projectiel);
        }

        public void StartLevel()
        {
            _projectiel_timer.Start();
        }
    }
}