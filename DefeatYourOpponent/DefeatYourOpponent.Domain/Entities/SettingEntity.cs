using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class SettingEntity
    {
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

        public SettingEntity(RiotControllerSettingEntity riotControllerSetting,
            string riotApiErrorMessageListFilePath,
            string internalErrorMessageListFilePath,
            string championsDataFilePath,
            string queueTypeListFilePath,
            int championImageWidth,
            int killIconWidth,
            int assistChampionImageWidth)
        {
            RiotControllerSetting = riotControllerSetting;
            RiotApiErrorMessageListFilePath = riotApiErrorMessageListFilePath;
            InternalErrorMessageListFilePath = internalErrorMessageListFilePath;
            ChampionsDataFilePath = championsDataFilePath;
            QueueTypeListFilePath = queueTypeListFilePath;
            ChampionImageWidth = championImageWidth;
            KillIconWidth = killIconWidth;
            AssistChampionImageWidth = assistChampionImageWidth;
        }
    }
}
