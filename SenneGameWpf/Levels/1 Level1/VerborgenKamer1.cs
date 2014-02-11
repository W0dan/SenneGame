using System.Windows;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels.Level1
{
    public class VerborgenKamer1 : VerborgenKamer
    {
        public VerborgenKamer1(Level level, Point offsetPosition, Size size)
            : base(level, offsetPosition, size)
        {
            MaakHindernissen();
        }

        public override void Ontdek()
        {
            base.Ontdek();
            MaakMonsterkes();
            MaakVerborgenKamers();
        }

        private void MaakVerborgenKamers()
        {
            var verborgenKamer = new VerborgenKamer2(Level, TranslatePoint(100, 0), new Size(100, 100));
            AddVerborgenKamer(verborgenKamer, new Point(95, 45));
        }

        private void MaakMonsterkes()
        {
            AddMonster<Heks>(50, 50);
        }

        private void MaakHindernissen()
        {
            for (var x = 5; x < 100; x += 10)
            {
                AddSteen(x, 5);
            }
            for (var y = 15; y < 100; y += 10)
            {
                AddSteen(5, y);
            }
            for (var y = 15; y < 45; y += 10)
            {
                AddSteen(95, y);
            }
            for (var y = 55; y < 100; y += 10)
            {
                AddSteen(95, y);
            }
        }

    }
}