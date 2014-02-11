using System.Windows;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels.Level2
{
    public class VerborgenKamer12 : VerborgenKamer
    {
        public VerborgenKamer12(Level level, Point offsetPosition, Size size)
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
            AddMonster<Zombie>(50, 50);
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 100; x += 10)
            {
                AddSteen(x, 5);
                AddSteen(x, 105);
            }
            for (var y = 15; y < 100; y += 10)
            {
                AddSteen(95, y);
            }
        }

    }
}