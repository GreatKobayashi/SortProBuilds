using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class MatchDetailViewSettingEntity
    {
        public MatchDetailViewSettingEntity(int titleChampionImageWidth, int timeLineChampionImageWidth, int eventItemImageWidth, int killIconWidth, int eventIconWidth, int assistChampionImageWidth)
        {
            TitleChampionImageWidth = titleChampionImageWidth;
            TimeLineChampionImageWidth = timeLineChampionImageWidth;
            EventItemImageWidth = eventItemImageWidth;
            KillIconWidth = killIconWidth;
            EventIconWidth = eventIconWidth;
            AssistChampionImageWidth = assistChampionImageWidth;
        }

        [JsonInclude]
        public int TitleChampionImageWidth { get; private set; }
        [JsonInclude]
        public int TimeLineChampionImageWidth { get; private set; }
        [JsonInclude]
        public int EventItemImageWidth { get; private set; }
        [JsonInclude]
        public int KillIconWidth { get; private set; }
        [JsonInclude]
        public int EventIconWidth { get; private set; }
        [JsonInclude]
        public int AssistChampionImageWidth { get; private set; }
    }
}
