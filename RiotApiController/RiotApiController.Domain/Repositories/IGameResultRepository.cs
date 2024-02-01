using RiotApiController.Domain.Entities;
using RiotSharp.Misc;

namespace RiotApiController.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetMatchDataAsync(long count, Region region, string puuId);
    }
}
