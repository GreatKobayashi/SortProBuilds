using RiotApiController.Domain.Entities.Commons;
using RiotApiController.Domain.Logics;
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

        public async Task<List<GameResultEntity>> GetGameResultAsync(long start, long count, Region region, string puuId)
        {
            region = region.ToArea();
            var matchList = await _riotApi.Match.GetMatchListAsync(region, puuId, start, count);
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
                var opponentChampion = match.Info.Participants.Find(p => p.TeamPosition == playerInfo.TeamPosition &&
                    p.TeamId != playerInfo.TeamId);
#pragma warning disable CS8602
                matchResultEntityList.Add(new(
                    match.Info.QueueId,
                    playerInfo.ChampionName,
                    win,
                    playerInfo.TeamPosition,
                    opponentChampion.ChampionName,
                    new List<long>()
                    {
                        playerInfo.Item0, playerInfo.Item1, playerInfo.Item2, playerInfo.Item3, playerInfo.Item4, playerInfo.Item5
                    },
                    playerInfo.Item6,
                    playerInfo.Kills, playerInfo.Deaths, playerInfo.Assists));
#pragma warning restore CS8602
            }
            return matchResultEntityList;
        }

        public async Task<string> GetPuuidAsync(Region region, string summonerName)
        {
            var summoner = await _riotApi.Summoner.GetSummonerByNameAsync(region, summonerName);
            return summoner.Puuid;
        }
    }
}
