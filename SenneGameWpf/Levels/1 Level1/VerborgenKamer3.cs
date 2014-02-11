using System.Windows;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels.Level1
{
    public class VerborgenKamer3 : VerborgenKamer
    {
        public VerborgenKamer3(Level level, Point offsetPosition, Size size)
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
            AddMonster<Heks>(50, 50);
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 100; x += 10)
            {
                AddSteen(x, 95);
            }
            for (var y = 15; y < 100; y += 10)
            {
                AddSteen(95, y);
            }
        }

    }
}