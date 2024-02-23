using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class ChampionDataEntity
    {
        [JsonInclude]
        public string Id { get; private set; }
        [JsonInclude]
        public string Key { get; private set; }
        [JsonInclude]
        public string Name { get; private set; }

        // ★TODO その他要素

        [JsonConstructor]
        public ChampionDataEntity(string id, string key, string name)
        {
            Id = id;
            Key = key;
            Name = name;
        }
    }
}
