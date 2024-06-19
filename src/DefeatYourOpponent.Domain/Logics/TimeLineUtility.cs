namespace DefeatYourOpponent.Domain.Logics
{
    public static class TimeLineUtility
    {
        private static double Adjustment(double gameDuration)
        {
            switch (gameDuration)
            {
                case > 35:
                    return 0.918;
                case > 33:
                    return 0.91;
                case > 25:
                    return 0.905;
                default:
                    return 0.894;
            }
        }

        public static int GetTimeLinePosition(double eventHappenedTime, double gameDuration)
        {
            return (int)(Shared.SettingEntity.ChartWidth * (eventHappenedTime / gameDuration) * Adjustment(gameDuration));
        }
    }
}
