using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Repositories;
using RiotSharp;
using RiotSharp.Misc;

namespace RiotApiController.Infrastructure.WebApi
{
    public class RiotApiWrapper : IGameResultRepository
    {
        private RiotApi _riotApi;

        public RiotApiWrapper(RiotApi riotApi)
        {
            _riotApi = riotApi;
        }

        public async Task<List<GameResultEntity>> GetMatchDataAsync(long count, Region region, string puuId)
        {
            var matchList = await _riotApi.Match.GetMatchListAsync(region, puuId, 0, count);
            var matchResultEntityList = new List<GameResultEntity>();
            foreach (var matchId in matchList)
            {
                var match = await _riotApi.Match.GetMatchAsync(region, matchId);
                var specifiedPlayerIndex = match.Metadata.Participants.IndexOf(puuId);
                var playerInfo = match.Info.Participants[specifiedPlayerIndex];

                bool win;
                if (playerInfo.TeamId == 100)
                {
                    win = match.Info.Teams[0].Win;
                }
                else
                {
                    win = match.Info.Teams[1].Win;
                }
                matchResultEntityList.Add(new(
                    playerInfo.ChampionName, win, playerInfo.TeamPosition));
            }
            return matchResultEntityList;
        }
    }
}
