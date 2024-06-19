using DefeatYourOpponent.Domain.Entities;
using RiotApiWrapper.Entities;
using RiotApiWrapper.Misc;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IApiRepository
    {
        public Task<MatchEntity> GetMatchAsync(Region region, string matchId);
        public Task<List<MatchEntity>> GetMatchesAsync(Region region, string riotId, string tagLine, SerchTagEntity tags, int count, int startOffset = 0);
        public Task<MatchTimeLineEntity> GetTimeLineAsync(Region region, string matchId);
    }
}
