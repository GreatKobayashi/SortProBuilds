using RiotApiController.Domain.Entities.Commons;
using RiotSharp.Misc;

namespace RiotApiController.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultAsync(long start, long count, Region region, string puuId);
        public Task<string> GetPuuidAsync(Region region, string summonerName);
        public Task<GameDetailEntity> GetGetGameDetailAsync(Region region, string matchId, int targetParticipantId, int opponentParticipantId);
    }
}
