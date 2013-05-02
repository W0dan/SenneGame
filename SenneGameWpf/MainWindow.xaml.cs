using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using SenneGameWpf.Levels;
using SenneGameWpf.Monsters;

namespace SenneGameWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private readonly ISpel _spel = new Spel();

        private DispatcherTimer _monster_timer;
        private DispatcherTimer _level_gedaan_timer;

        private int _huidigeLevel;
        private bool _game_over;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _monster_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            _monster_timer.Tick += MonsterTimerElapsed;

            _level_gedaan_timer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 100) };
            _level_gedaan_timer.Tick += LevelGedaanTimerElapsed;

            _huidigeLevel = 1;
            HuidigeLevel = LevelFactory.CreateLevel(_huidigeLevel, _spel);

            Start_level();
        }

        public Level HuidigeLevel { get; set; }

        private void Start_level()
        {
            _spel.StartLevel();

            _monster_timer.Start();

            TekenBlad.Source = Teken_game();
        }

        void LevelGedaanTimerElapsed(object sender, EventArgs e)
        {
            _level_gedaan_timer.Stop();

            HuidigeLevel = LevelFactory.CreateLevel(_huidigeLevel, _spel);

            if (HuidigeLevel == null)
            {
                Gewonnen();
            }
            else
            {
                Start_level();
            }
        }

        private void GameOver()
        {
            _game_over = true;
            TekenBlad.Source = new DrawingImage(_spel.Teken_gameOver());
        }

        private void Gewonnen()
        {
            TekenBlad.Source = new DrawingImage(_spel.Teken_gewonnen());
        }

        private void Level_gedaan()
        {
            _monster_timer.Stop();

            if (_spel.Is_gewonnen)
            {
                _huidigeLevel++;
                _level_gedaan_timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
                _level_gedaan_timer.Start();
            }
            else
            {
                GameOver();
            }

        }

        private void MonsterTimerElapsed(object sender, EventArgs e)
        {
            _monster_timer.Stop();

            if (_spel._ventje_heeft_timeout > 0)
            {
                _spel._ventje_heeft_timeout--;
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

            if (_spel.Level_is_gedaan)
            {
                Level_gedaan();
                return;
            }

            TekenBlad.Source = Teken_game();

            _monster_timer.Start();
        }

        private DrawingImage Teken_game()
        {
            var game_tekening = new DrawingGroup();

            game_tekening.Children.Add(_spel.Teken_jezelf());

            return new DrawingImage(game_tekening);
        }

        private void TekenBlad_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_spel.Level_is_gedaan || _game_over)
                return;

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.Up: //op, boven
                        _spel.Ventje_schiet_naar_boven();
                        break;
                    case Key.Down: //neer, beneden
                        _spel.Ventje_schiet_naar_beneden();
                        break;
                    case Key.Left: //links
                        _spel.Ventje_schiet_naar_links();
                        break;
                    case Key.Right: //rechts
                        _spel.Ventje_schiet_naar_rechts();
                        break;
                    default:
                        return;
                }
            }
            else
                switch (e.Key)
                {
                    case Key.Up: //op, boven
                        HuidigeLevel.Ventje.Beweeg_naar_boven();
                        break;
                    case Key.Down: //neer, beneden
                        HuidigeLevel.Ventje.Beweeg_naar_beneden();
                        break;
                    case Key.Left: //links
                        HuidigeLevel.Ventje.Beweeg_naar_links();
                        break;
                    case Key.Right: //rechts
                        HuidigeLevel.Ventje.Beweeg_naar_rechts();
                        break;
                }

            TekenBlad.Source = Teken_game();
        }
    }
}
