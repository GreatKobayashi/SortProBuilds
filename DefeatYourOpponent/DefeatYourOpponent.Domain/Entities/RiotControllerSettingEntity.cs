using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class RiotControllerSettingEntity
    {
        private string _getGameResultsApiUrlKey = "GetGameResults";

        [JsonInclude]
        public string BaseUrl { get; private set; }

        [JsonInclude]
        public Dictionary<string, string> ApiUrls { get; private set; }

        public RiotControllerSettingEntity(string baseUrl, Dictionary<string, string> apiUrls)
        {
            BaseUrl = baseUrl;
            ApiUrls = apiUrls;
        }

        public string GetGameResultsUrl
        {
            get
            {
                ApiUrls.TryGetValue(_getGameResultsApiUrlKey, out string? url);
                return url != null ? url : throw new Exception("URL設定なし");
            }
        }
    }
}
