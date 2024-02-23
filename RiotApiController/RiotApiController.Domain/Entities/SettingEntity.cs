using System.Text.Json.Serialization;

namespace RiotApiController.Domain.Entities
{
    public class SettingEntity
    {
        [JsonInclude]
        public string ConnectionString { get; private set; }

        [JsonInclude]
        public int MaxTryCount { get; private set; }

        public SettingEntity(string connectionString, int maxTryCount)
        {
            ConnectionString = connectionString;
            MaxTryCount = maxTryCount;
        }
    }
}
