using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities
{
    public class MatchIndexViewSettingEntity
    {
        public MatchIndexViewSettingEntity(int championImageWidth, int summonerSpellImageWidth, int itemImageWidth)
        {
            ChampionImageWidth = championImageWidth;
            SummonerSpellImageWidth = summonerSpellImageWidth;
            ItemImageWidth = itemImageWidth;
        }

        [JsonInclude]
        public int ChampionImageWidth { get; private set; }
        [JsonInclude]
        public int SummonerSpellImageWidth { get; private set; }
        [JsonInclude]
        public int ItemImageWidth { get; private set; }
    }
}
