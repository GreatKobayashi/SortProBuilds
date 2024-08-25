using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiWrapper;
using RiotApiWrapper.Entities;
using RiotApiWrapper.Misc;

namespace DefeatYourOpponent.Infrastructure.WebApi
{
    public class RiotApiWrapperApi : IApiRepository
    {
        private static readonly int _maxMatchCount = 100;
        private RiotApi _riotApi;

        public RiotApiWrapperApi(string apiKey)
        {
            _riotApi = new(apiKey);
        }

        public Task<MatchEntity> GetMatchAsync(Region region, string matchId)
        {
            return _riotApi.Match.GetInfoAsync(region, matchId);
        }

        public async Task<List<MatchEntity>> GetMatchesAsync(Region region, string riotId, string tagLine, SerchTagEntity tags, int count, int startOffset = 0)
        {
            var account = await _riotApi.Account.GetByGameIdAsync(region, riotId, tagLine);
            var matchIdList = await _riotApi.Match.GetIdListAsync(region, account.PuuId, null, null, null, startOffset, _maxMatchCount);

            var matchInfoList = new List<MatchEntity>();
            foreach (var matchId in matchIdList)
            {
                try
                {
                    var match = await _riotApi.Match.GetInfoAsync(region, matchId);
                    var target = match.Participants.First(x => x.Summoner.GameName == riotId);
                    if ((tags.Champion != null && target.Champion.Id != tags.Champion.Id)
                        || (tags.Win != null && target.Win != tags.Win)
                        || (tags.Position != null && target.Position != tags.Position)
                        || (tags.QueueType != null && match.Meta.Queue != tags.QueueType))
                    {
                        continue;
                    }
                    matchInfoList.Add(match);
                    if (matchInfoList.Count == count)
                    {
                        break;
                    }
                }
                catch { }
                finally
                {
                }
            }

            return matchInfoList;
        }

        public async Task<MatchTimeLineEntity> GetTimeLineAsync(Region region, string matchId)
        {
            return await _riotApi.Match.GetTimeLineAsync(region, matchId);
        }
    }
}
