using Core.Categories;

namespace Core.Helpers
{
    public static class LevelsHelper
    {
        public static Levels GetLevel(double todayRelative)
        {
            return todayRelative switch
            {
                <= 0 => Levels.Empty,
                _ when todayRelative <= 0.1 => Levels.Low,
                _ when todayRelative < 1 => Levels.Normal,
                _ => Levels.Full,
            };
        }
    }
}
