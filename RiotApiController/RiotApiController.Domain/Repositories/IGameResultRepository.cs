using RiotApiController.Domain.Entities;
using RiotSharp.Misc;

namespace RiotApiController.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultAsync(long start, long count, Region region, string puuId);
        public Task<string> GetPuuidAsync(Region region, string summonerName);
    }
}
