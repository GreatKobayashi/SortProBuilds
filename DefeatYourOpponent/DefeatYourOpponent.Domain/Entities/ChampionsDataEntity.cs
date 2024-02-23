using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class ChampionsDataEntity
    {
        [JsonInclude]
        public string Type { get; private set; }
        [JsonInclude]
        public string Version { get; private set; }
        [JsonInclude]
        public Dictionary<string, ChampionDataEntity> Data { get; private set; }

        [JsonConstructor]
        public ChampionsDataEntity(string type, string version, Dictionary<string, ChampionDataEntity> data)
        {
            Type = type;
            Version = version;
            Data = data;
        }
    }
}
