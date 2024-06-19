using DefeatYourOpponent.Domain.Logics;

namespace DefeatYourOpponent.Domain.Entities
{
    public class TimeBarEntity
    {
        public List<int> EventTimeTicks { get; } = new List<int>();
        public double LastEventHappenedTime { get; }

        public TimeBarEntity(double gameDuration)
        {
            var tickMinute = 0;
            while (gameDuration > tickMinute)
            {
                EventTimeTicks.Add(TimeLineUtility.GetTimeLinePosition(tickMinute, gameDuration));
                tickMinute += Shared.SettingEntity.TimeLineTickInterval;
            }
        }

        public string GetTickLabel(int eventTimeTick)
        {
            var index = EventTimeTicks.IndexOf(eventTimeTick);
            return new TimeSpan(0, 0, index * Shared.SettingEntity.TimeLineTickInterval, 0).ToString(@"mm\:ss");
        }
    }
}
