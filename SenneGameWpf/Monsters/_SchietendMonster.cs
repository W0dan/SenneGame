using System.Windows;
using SenneGameWpf.Projectiel_van_monsterke;

namespace SenneGameWpf.Monsters
{
    public abstract class SchietendMonster : Monster
    {
        protected SchietendMonster(ISpel spel, Point waar_ben_ik) : base(spel, waar_ben_ik)
        {
        }

        protected void Schiet_naar_links()
        {
            var projectiel = new ProjectielVanMonsterkeNaarLinks(Spel, WaarBenIk);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_beneden()
        {
            var projectiel = new ProjectielVanMonsterkeNaarBeneden(Spel, WaarBenIk);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_boven()
        {
            var projectiel = new ProjectielVanMonsterkeNaarBoven(Spel, WaarBenIk);
            Spel.Monsterke_schiet(projectiel);
        }

        protected void Schiet_naar_rechts()
        {
            var projectiel = new ProjectielVanMonsterkeNaarRechts(Spel, WaarBenIk);
            Spel.Monsterke_schiet(projectiel);
        }
    }
}