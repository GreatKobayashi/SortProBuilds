using DefeatYourOpponent.Domain.Entities.Commons;
using RiotSharp.Misc;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultEntitiesAsync(Region region, string summonerName, TagEntity tags, int count);
    }
}
