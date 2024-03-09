using Microsoft.Extensions.DependencyModel;
using RiotApiController.Domain.Entities.Commons;
using RiotApiController.Domain.Helper;
using RiotApiController.Domain.Logics;
using RiotApiController.Domain.Repositories;
using RiotSharp;
using RiotSharp.Endpoints.MatchEndpoint;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
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
                var targetInfo = match.Info.Participants[specifiedPlayerIndex];

                bool win;
                if (targetInfo.TeamId == 100)
                {
                    win = match.Info.Teams[0].Win;
                }
                else
                {
                    win = match.Info.Teams[1].Win;
                }
                var opponentInfo = match.Info.Participants.Find(p => p.TeamPosition == targetInfo.TeamPosition &&
                    p.TeamId != targetInfo.TeamId);
#pragma warning disable CS8602
                matchResultEntityList.Add(new(
                    matchId,
                    match.Info.QueueId,
                    targetInfo.ParticipantId,
                    opponentInfo.ParticipantId,
                    win,
                    opponentInfo.ChampionName,
                    GetPlayerDataEntity(targetInfo)
                    ));
#pragma warning restore CS8602
            }
            return matchResultEntityList;
        }

        public async Task<string> GetPuuidAsync(Region region, string summonerName)
        {
            var summoner = await _riotApi.Summoner.GetSummonerByNameAsync(region, summonerName);
            return summoner.Puuid;
        }

        public async Task<GameDetailEntity> GetGetGameDetailAsync(Region region, string matchId, int targetId, int opponentId)
        {
            // JP1_434966173
            region = region.ToArea();
            var defaultTimeLine = await _riotApi.Match.GetMatchTimelineAsync(region, matchId);
            var formatedTimeLine = new TimeLineEntity();
            foreach (var frame in defaultTimeLine.Info.Frames)
            {
                foreach (var evnt in frame.Events)
                {
                    if (evnt.EventType == MatchEventType.ItemPurchased &&
                        (evnt.ParticipantId == targetId || evnt.ParticipantId == opponentId))
                    {
                        var purchaseData = new EventDataEntity(evnt.Timestamp);
                        purchaseData.EventData.Add(nameof(evnt.ParticipantId), evnt.ParticipantId);
                        purchaseData.EventData.Add(nameof(evnt.ItemId), evnt.ItemId);
                        formatedTimeLine.PurchaseData.Add(purchaseData);
                    }

                    if (evnt.EventType == MatchEventType.ChampionKill &&
                        (evnt.ParticipantId == targetId || evnt.ParticipantId == opponentId ||
                        evnt.VictimId == targetId || evnt.VictimId == opponentId ||
                        (evnt.AssistingParticipantIds != null && (evnt.AssistingParticipantIds.Contains(targetId) || evnt.AssistingParticipantIds.Contains(opponentId)))))
                    {
                        var killData = new EventDataEntity(evnt.Timestamp);
                        killData.EventData.Add(nameof(evnt.ParticipantId), evnt.ParticipantId);
                        killData.EventData.Add(nameof(evnt.VictimId), evnt.VictimId);
                        if (evnt.AssistingParticipantIds != null)
                        {
                            killData.EventData.Add(nameof(evnt.AssistingParticipantIds), evnt.AssistingParticipantIds);
                        }
                        formatedTimeLine.KillData.Add(killData);
                    }
                }

                foreach (var participantFrame in frame.ParticipantFrames)
                {
                    if (participantFrame.Key == targetId.ToString() ||
                        participantFrame.Key == opponentId.ToString())
                    {
                        var goldData = new EventDataEntity(frame.Timestamp);
                        goldData.EventData.Add(nameof(participantFrame.Value.ParticipantId), participantFrame.Value.ParticipantId);
                        goldData.EventData.Add(nameof(participantFrame.Value.CurrentGold), participantFrame.Value.CurrentGold);
                        goldData.EventData.Add(nameof(participantFrame.Value.TotalGold), participantFrame.Value.TotalGold);
                        goldData.EventData.Add(nameof(participantFrame.Value.MinionsKilled), participantFrame.Value.MinionsKilled);
                        goldData.EventData.Add(nameof(participantFrame.Value.JungleMinionsKilled), participantFrame.Value.JungleMinionsKilled);
                        formatedTimeLine.GoldData.Add(goldData);
                    }
                }
            }

            var match = await _riotApi.Match.GetMatchAsync(region, matchId);
            var targetPlayerData = GetPlayerDataEntity(match.Info.Participants.First(x => x.ParticipantId == targetId));
            var opponentPlayerData = GetPlayerDataEntity(match.Info.Participants.First(x => x.ParticipantId == opponentId));

            return new(formatedTimeLine, new()
            {
                targetPlayerData, opponentPlayerData
            });
        }

        private PlayerDataEntity GetPlayerDataEntity(Participant targetInfo)
        {
            return new(
                targetInfo.ParticipantId,
                targetInfo.ChampionName,
                targetInfo.TeamPosition,
                new List<long>()
                {
                    targetInfo.Item0, targetInfo.Item1, targetInfo.Item2, targetInfo.Item3, targetInfo.Item4, targetInfo.Item5
                },
                targetInfo.Item6,
                targetInfo.Kills,
                targetInfo.Deaths,
                targetInfo.Assists);
        }
    }
}
