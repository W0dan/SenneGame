using System.Windows;
using System.Windows.Input;

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

        private ISpel _spel;

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            _spel = new Spel(TekenBlad);
        }

        private void TekenBlad_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_spel.Level_is_gedaan || _spel.Is_gameover)
                return;

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                switch (e.Key)
                {
                    case Key.Up: //op, boven
                        _spel.Ventje_schiet(Direction.Up);
                        break;
                    case Key.Down: //neer, beneden
                        _spel.Ventje_schiet(Direction.Down);
                        break;
                    case Key.Left: //links
                        _spel.Ventje_schiet(Direction.Left);
                        break;
                    case Key.Right: //rechts
                        _spel.Ventje_schiet(Direction.Right);
                        break;
                    default:
                        return;
                }
            }
            else
                switch (e.Key)
                {
                    case Key.Up: //op, boven
                        _spel.HuidigeLevel.Ventje.Beweeg_naar_boven();
                        break;
                    case Key.Down: //neer, beneden
                        _spel.HuidigeLevel.Ventje.Beweeg_naar_beneden();
                        break;
                    case Key.Left: //links
                        _spel.HuidigeLevel.Ventje.Beweeg_naar_links();
                        break;
                    case Key.Right: //rechts
                        _spel.HuidigeLevel.Ventje.Beweeg_naar_rechts();
                        break;
                }

            TekenBlad.Source = _spel.Teken_game();
        }
    }
}
