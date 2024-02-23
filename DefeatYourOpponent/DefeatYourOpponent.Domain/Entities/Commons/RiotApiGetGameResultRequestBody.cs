using DefeatYourOpponent.Domain.Entities.Commons;
using RiotSharp.Misc;

namespace DefeatYourOpponent.Domain.Entities
{
    public class RiotApiGetGameResultRequestBody
    {
        public Region Region { get; }
        public string SummonerName { get; }
        public TagEntity Tags { get; }
        public int Count { get; }

        public RiotApiGetGameResultRequestBody(Region region, string summonerName, TagEntity tags, int count)
        {
            Region = region;
            SummonerName = summonerName;
            Tags = tags;
            Count = count;
        }
    }
}
