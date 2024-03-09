using DefeatYourOpponent.Domain.Entities.Commons;
using RiotSharp.Misc;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface ITimeLineRepository
    {
        public Task<GameDetailEntity> GetGameDetailAsync(Region region, string matchId, int targetId, int opponentId);
    }
}
