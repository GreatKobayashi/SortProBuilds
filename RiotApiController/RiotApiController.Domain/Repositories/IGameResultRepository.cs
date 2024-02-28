using RiotApiController.Domain.Entities.Commons;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Misc;

namespace RiotApiController.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultAsync(long start, long count, Region region, string puuId);
        public Task<string> GetPuuidAsync(Region region, string summonerName);
        public Task<TimeLineEntity> GetTimeLine(Region region, string gameId, int targetParticipantId, int opponentParticipantId);
    }
}
