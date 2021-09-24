namespace Core.Helpers
{
    public static class LevelsHelper
    {
        public static Levels GetLevel(double todayRelative)
        {
            return todayRelative switch
            {
                <= 0 => Levels.Empty,
                <= 0.1 => Levels.Low,
                < 1 => Levels.Normal,
                _ => Levels.Full,
            };
        }
    }
}
