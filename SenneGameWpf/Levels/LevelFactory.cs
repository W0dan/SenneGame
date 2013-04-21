namespace SenneGameWpf.Levels
{
    public class LevelFactory
    {
        public static Level CreateLevel(int level, ISpel spel)
        {
            switch (level)
            {
                case 1:
                    return new Level1(spel);
                case 2:
                    return new Level2(spel);
                case 3:
                    return new Level3(spel);
                case 4:
                    return new Level4(spel);
                case 5:
                    return new Level5(spel);
                case 6:
                    return new Level6(spel);
                case 7:
                    return new Level7(spel);
                case 8:
                    return new Level8(spel);
                case 9:
                    return new Level9(spel);
                case 10:
                    return new HanneLevel(spel);
                default:
                    return null;
            }
        }
    }
}