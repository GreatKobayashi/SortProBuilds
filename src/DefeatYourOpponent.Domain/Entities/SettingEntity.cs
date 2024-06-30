using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class SettingEntity
    {
        public SettingEntity(
            string riotApiErrorMessageListFilePath,
            string internalErrorMessageListFilePath,
            string apiKeyFilePath,
            MatchIndexViewSettingEntity matchIndexViewSetting,
            MatchDetailViewSettingEntity matchDetailViewSetting,
            int chartWidth,
            int timeLineTickInterval)
        {
            RiotApiErrorMessageListFilePath = riotApiErrorMessageListFilePath;
            InternalErrorMessageListFilePath = internalErrorMessageListFilePath;
            ApiKeyFilePath = apiKeyFilePath;
            MatchIndexViewSetting = matchIndexViewSetting;
            MatchDetailViewSetting = matchDetailViewSetting;
            ChartWidth = chartWidth;
            TimeLineTickInterval = timeLineTickInterval;
        }

        [JsonInclude]
        public string RiotApiErrorMessageListFilePath { get; private set; }
        [JsonInclude]
        public string InternalErrorMessageListFilePath { get; private set; }
        [JsonInclude]
        public string ApiKeyFilePath { get; private set; }
        [JsonInclude]
        public MatchIndexViewSettingEntity MatchIndexViewSetting { get; private set; }
        [JsonInclude]
        public MatchDetailViewSettingEntity MatchDetailViewSetting { get; private set; }
        [JsonInclude]
        public int ChartWidth { get; private set; }
        [JsonInclude]
        public int TimeLineTickInterval { get; private set; }
    }
}
