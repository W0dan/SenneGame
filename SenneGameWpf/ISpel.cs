using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Levels;
using SenneGameWpf.Monsters;

namespace SenneGameWpf
{
    public interface ISpel
    {
        bool Level_is_gedaan { get; }
        bool Is_er_een_hindernis_in_de_weg(Point plek, Size grootte);
        bool Is_er_een_monster_in_de_weg(Point plek, Size grootte);
        bool Is_er_een_monster_in_de_weg(Point plek, Size grootte, Monster ikke);
        bool Is_hier_de_uitgang(Point plek, Size grootte);
        bool Is_hier_het_ventje(Point plek, Size grootte);
        object Is_er_iets_geraakt(Point plek, Size grootte);
        Drawing Teken_jezelf();
        Ventje Zet_ventje(Point point);
        void GameOver();
        void Win();
        Drawing Teken_gewonnen();

        bool Is_gameover { get; }
        bool Is_gewonnen { get; }
        Level Level { get; set; }
        Drawing Teken_gameOver();
        Drawing Teken_probeer_opnieuw();

        void Ventje_schiet(Direction direction);

        void StartLevel();
        void Monsterke_schiet(IProjectiel projectiel);
        void Ventje_is_geraakt();
        int _ventje_heeft_timeout { get; set; }

        Level HuidigeLevel { get; set; }
    }
}