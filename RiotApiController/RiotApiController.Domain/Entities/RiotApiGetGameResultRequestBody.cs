using RiotSharp.Misc;

namespace RiotApiController.Domain.Entities
{
    public class RiotApiGetGameResultRequestBody
    {
        public Region Region { get; set; }
        public string SummonerName { get; set; }
        public Dictionary<string, string> Tags { get; set; }

        public RiotApiGetGameResultRequestBody()
        {
            SummonerName = string.Empty;
            Tags = new Dictionary<string, string>();
        }
    }
}
