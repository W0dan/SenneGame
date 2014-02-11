namespace SenneGameWpf.Levels
{
    public class LevelFactory
    {
        public static Level CreateLevel(int level, ISpel spel)
        {
            switch (level)
            {
                case 1:
                    return new Level1.Level1(spel);
                case 2:
                    return new Level2.Level2(spel);
                case 3:
                    return new HeksenGrotLevel(spel);
                case 4:
                    return new GevangenGigantLevel(spel);
                case 5:
                    return new BluesLevel(spel);
                case 6:
                    return new ZombiesEnGigantenLevel(spel);
                case 7:
                    return new KerkhofLevel(spel);
                case 8:
                    return new TrollenLevel(spel);
                case 9:
                    return new GrootKruisLevel(spel);
                case 10:
                    return new PiratenLevel(spel);
                default:
                    return null;
            }
        }
    }
}