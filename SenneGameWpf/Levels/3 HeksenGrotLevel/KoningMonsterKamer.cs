using System.Windows;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels
{
    public class KoningMonsterKamer : VerborgenKamer
    {
        public KoningMonsterKamer(Level level, Point offsetPosition, Size size) 
            : base(level, offsetPosition, size)
        {
            MaakHindernissen();
        }

        public override void Ontdek()
        {
            base.Ontdek();
            MaakMonsterkes();
        }

        private void MaakMonsterkes()
        {
            AddMonster<KoningMonster>(50, 50);
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 100; x += 10)
            {
                AddSteen(x, 5);
            }
            for (var x = 5; x < 100; x += 10)
            {
                AddSteen(x, 95);
            }
            for (var y = 15; y < 90; y += 10)
            {
                AddSteen(5, y);
            }
        }

    }
}