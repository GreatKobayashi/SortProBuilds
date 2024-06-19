using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class SettingEntity
    {
        public SettingEntity(RiotControllerSettingEntity riotControllerSetting,
            string riotApiErrorMessageListFilePath,
            string internalErrorMessageListFilePath,
            string championsDataFilePath,
            string queueTypeListFilePath,
            int championImageWidth,
            int killIconWidth,
            int assistChampionImageWidth,
            int chartWidth)
        {
            RiotControllerSetting = riotControllerSetting;
            RiotApiErrorMessageListFilePath = riotApiErrorMessageListFilePath;
            InternalErrorMessageListFilePath = internalErrorMessageListFilePath;
            ChampionsDataFilePath = championsDataFilePath;
            QueueTypeListFilePath = queueTypeListFilePath;
            ChampionImageWidth = championImageWidth;
            KillIconWidth = killIconWidth;
            AssistChampionImageWidth = assistChampionImageWidth;
            ChartWidth = chartWidth;
        }

        [JsonInclude]
        public RiotControllerSettingEntity RiotControllerSetting { get; private set; }
        [JsonInclude]
        public string RiotApiErrorMessageListFilePath { get; private set; }
        [JsonInclude]
        public string InternalErrorMessageListFilePath { get; private set; }
        [JsonInclude]
        public string ChampionsDataFilePath { get; private set; }
        [JsonInclude]
        public string QueueTypeListFilePath { get; private set; }
        [JsonInclude]
        public int ChampionImageWidth { get; private set; }
        [JsonInclude]
        public int KillIconWidth { get; private set; }
        [JsonInclude]
        public int AssistChampionImageWidth { get; private set; }
        [JsonInclude]
        public int ChartWidth { get; private set; }
        [JsonInclude]
        public int TimeLineTickInterval { get; private set; }
    }
}
