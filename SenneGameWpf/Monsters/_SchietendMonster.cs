using System.Windows;
using System.Windows.Media;
using SenneGameWpf.Projectiel_van_monsterke;

namespace SenneGameWpf.Monsters
{
    public abstract class SchietendMonster : Monster
    {
        private readonly Brush _projectielKleur;

        protected SchietendMonster(Brush projectielKleur)
        {
            _projectielKleur = projectielKleur;
        }

        protected SchietendMonster(Size hoeGrootBenIk, int snelheid, Brush projectielKleur)
            : base(hoeGrootBenIk, snelheid)
        {
            _projectielKleur = projectielKleur;
        }

        protected void Schiet_naar_links()
        {
            var projectiel = new ProjectielVanMonsterkeNaarLinks(Spel, WaarBenIk, _projectielKleur);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_beneden()
        {
            var projectiel = new ProjectielVanMonsterkeNaarBeneden(Spel, WaarBenIk, _projectielKleur);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_boven()
        {
            var projectiel = new ProjectielVanMonsterkeNaarBoven(Spel, WaarBenIk, _projectielKleur);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_rechts()
        {
            var projectiel = new ProjectielVanMonsterkeNaarRechts(Spel, WaarBenIk, _projectielKleur);
            Spel.Monsterke_schiet(projectiel);
        }
    }
}