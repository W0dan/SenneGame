using System.Windows;
using SenneGameWpf.Monsters;

namespace SenneGameWpf.Levels.Level1
{
    public class VerborgenKamer2 : VerborgenKamer
    {
        public VerborgenKamer2(Level level, Point offsetPosition, Size size)
            : base(level, offsetPosition, size)
        {
            MaakHindernissen();
        }

        public override void Ontdek()
        {
            base.Ontdek();
            MaakVerborgenKamers();
            MaakMonsterkes();
        }

        private void MaakVerborgenKamers()
        {
            var verborgenKamer = new VerborgenKamer3(Level, TranslatePoint(0, 100), new Size(100, 100));
            AddVerborgenKamer(verborgenKamer, new Point(55, 105));
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
            for (var x = 5; x < 50; x += 10)
            {
                AddSteen(x, 105);
            }
            for (var x = 65; x < 100; x += 10)
            {
                AddSteen(x, 105);
            }
            for (var y = 15; y < 100; y += 10)
            {
                AddSteen(95, y);
            }
        }

    }
}