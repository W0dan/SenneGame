using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using SenneGameWpf.Hindernissen;
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
        private readonly DispatcherTimer _monster_timer;

        private readonly System.Windows.Controls.Image _tekenBlad;

        public int _ventje_heeft_timeout
        {
            get { return _ventje.Heb_timeout; }
            set { _ventje.Heb_timeout = value; }
        }

        private int _huidigeLevel;
        public Level HuidigeLevel { get; set; }

        public Spel(System.Windows.Controls.Image tekenBlad)
        {
            _tekenBlad = tekenBlad;

            _monster_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            _monster_timer.Tick += MonsterTimerElapsed;

            _projectiel_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 5) };
            _projectiel_timer.Tick += ProjectielTimerElapsed;

            _huidigeLevel = 1;
            HuidigeLevel = LevelFactory.CreateLevel(_huidigeLevel, this);

            StartLevel();
        }

        private void MonsterTimerElapsed(object sender, EventArgs e)
        {
            _monster_timer.Stop();

            if (_ventje_heeft_timeout > 0)
            {
                _ventje_heeft_timeout--;
            }

            var dode_monsterkes = new List<Monster>();

            foreach (var monsterke in HuidigeLevel.Monsterkes)
            {
                monsterke.Beweeg();
                if (monsterke.Is_dood)
                {
                    dode_monsterkes.Add(monsterke);
                }
            }

            foreach (var doodMonsterke in dode_monsterkes)
            {
                HuidigeLevel.Monsterkes.Remove(doodMonsterke);
            }

            if (Level_is_gedaan)
            {
                Level_gedaan();
                return;
            }

            _tekenBlad.Source = Teken_game();

            _monster_timer.Start();
        }

        private void Level_gedaan()
        {
            _monster_timer.Stop();

            if (Is_gewonnen)
            {
                HuidigeLevel = LevelFactory.CreateLevel(++_huidigeLevel, this);

                if (HuidigeLevel == null)
                {
                    Gewonnen();
                }
                else
                {
                    StartLevel();
                }
            }
            else
            {
                GameOver();
            }
        }

        private void Gewonnen()
        {
            _tekenBlad.Source = new DrawingImage(Teken_gewonnen());
        }

        private void ProjectielTimerElapsed(object sender, EventArgs e)
        {
            _projectiel_timer.Stop();

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

            _projectiel_timer.Start();
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

        public bool Is_gameover { get { return _is_gameOver; } }
        public bool Is_gewonnen { get { return _is_gewonnen; } }

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
            _monster_timer.Stop();

            _tekenBlad.Source = Teken_gameOver();
        }

        public void Win()
        {
            _is_gewonnen = true;
        }

        public void Ventje_schiet(Direction direction)
        {
            var projectiel = _level.Ventje.Schiet(direction);
            if (projectiel != null)
                _projectielen.Add(projectiel);
        }

        public void Monsterke_schiet(IProjectiel projectiel)
        {
            _projectielen.Add(projectiel);
        }

        public void StartLevel()
        {
            _projectiel_timer.Start();

            _monster_timer.Start();

            _tekenBlad.Source = Teken_game();
        }

        #region collission detection routines

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

        public Hindernis Hindernis_in_de_weg(Point plek, Size grootte)
        {
            foreach (var hindernis in _level.Hindernissen)
            {
                if (Math.Abs(plek.X - hindernis.X) < (5 + grootte.Width / 2)
                    && Math.Abs(plek.Y - hindernis.Y) < Math.Abs(5 + grootte.Height / 2))
                    return hindernis;
            }

            return null;
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
            var hindernisInDeWeg = Hindernis_in_de_weg(plek, grootte);
            if (hindernisInDeWeg != null)
            {
                if (hindernisInDeWeg.IsDestructable)
                {
                    var destroyedHindernis = (DestructableHindernis) hindernisInDeWeg;
                    destroyedHindernis.Destroy();
                    _level.Hindernissen.Remove(hindernisInDeWeg);
                }
                return Plek_is_bezet_door.Hindernis;
            }

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
                    if (monsterke.Is_dood)
                    {
                        _ventje.MonsterGedood(monsterke);
                    }
                    if (_level.Monsterkes.All(x => x.Is_dood))
                    {
                        _level.Hindernissen.Remove(_level.Uitgang);
                    }
                    return monsterke;
                }
            }

            return null;
        }

        #endregion

        #region graphics routines

        public DrawingImage Teken_game()
        {
            var game_tekening = new DrawingGroup();

            game_tekening.Children.Add(Teken_jezelf());

            return new DrawingImage(game_tekening);
        }

        private DrawingImage Teken_gameOver()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/gameover2.jpg");
            var gameover = new ImageDrawing(imageSource, new Rect(0, 0, 600, 270));

            var speelveld = new DrawingGroup();
            speelveld.Children.Add(gameover);
            return new DrawingImage( speelveld);
        }

        private Drawing Teken_jezelf()
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

        private Drawing Teken_gewonnen()
        {
            var imageSource = Resources.GetImage("SenneGameWpf", "images/win.jpg");
            var gewonnen = new ImageDrawing(imageSource, new Rect(0, 0, 1000, 667));

            var speelveld = new DrawingGroup();
            speelveld.Children.Add(gewonnen);
            return speelveld;
        }

        #endregion
    }
}