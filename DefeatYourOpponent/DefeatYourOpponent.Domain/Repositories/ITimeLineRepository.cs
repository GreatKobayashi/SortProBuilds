using DefeatYourOpponent.Domain.Entities.Commons;
using RiotSharp.Misc;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface ITimeLineRepository
    {
        public TimeLineEntity GetTimeLineAsync(Region region, string gameId, int targetId, int opponentId);
    }
}
