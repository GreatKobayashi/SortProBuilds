using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Misc;
using DefeatYourOpponent.Domain.Repositories;
using Reactive.Bindings;
using RiotApiWrapper.Entities;
using RiotApiWrapper.Entities.Match.MatchTimeLine.Events;
using RiotApiWrapper.Misc;
using System;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class MatchDetailViewModel
    {
        private IApiRepository _apiRepository;
        private List<ViewTimeLineEventEntity>? _yourChampionKillEventFramesCash;
        private List<ViewTimeLineEventEntity>? _opponentChampionKillEventFramesCash;
        private List<ViewTimeLineEventEntity>? _yourPurchaseEventFramesCash;
        private List<ViewTimeLineEventEntity>? _opponentPurchaseEventFramesCash;

        public ReactivePropertySlim<MatchTimeLineEntity> TimeLine { get; } = new();
        public ReactivePropertySlim<MatchEntity> Match { get; } = new();
        public int YourId { get; private set; }
        public int OpponentId { get; private set; }
        public ChampionEntity? YourChampion { get; set; }
        public ChampionEntity? OpponentChampion { get; set; }
        public ReactivePropertySlim<(List<int>, List<int>)> GraphData { get; } = new();
        public ReactivePropertySlim<List<ViewTimeLineEventEntity>> YourEventFrames { get; } = new();
        public ReactivePropertySlim<List<ViewTimeLineEventEntity>> OpponentEventFrames { get; } = new();
        public ReactivePropertySlim<GraphContent> GraphContentSelected { get; set; } = new();
        public ReactivePropertySlim<EventType> EventTypeSelected { get; set; } = new();

        public bool IsInitialized { get; private set; } = false;


        public MatchDetailViewModel(IApiRepository apiRepository)
        {
            _apiRepository = apiRepository;

            EventTypeSelected.Value = EventType.Kill;
            EventTypeSelected.Subscribe(x => OnTimeLineContentSelect());

            GraphContentSelected.Value = GraphContent.TotalGold;
            GraphContentSelected.Subscribe(x => OnGraphContentSelect());
        }

        public async Task InitializeAsync(Region region, string matchId, int yourId, int opponentId)
        {
            TimeLine.Value = await _apiRepository.GetTimeLineAsync(region, matchId);
            Match.Value = await _apiRepository.GetMatchAsync(region, matchId);

            SetParticipantId(yourId, opponentId);

            OnGraphContentSelect();
            OnTimeLineContentSelect();

            IsInitialized = true;
        }

        private void SetParticipantId(int yourId, int opponentId)
        {
            YourId = yourId;
            OpponentId = opponentId;

            YourChampion = Match.Value.Participants.First(x => x.Id == YourId).Champion;
            OpponentChampion = Match.Value.Participants.First(x => x.Id == OpponentId).Champion;
        }

        public void OnGraphContentSelect()
        {
            if (TimeLine.Value == null)
            {
                return;
            }
            var yourGoldData = TimeLine.Value.StatPerMinute.ConvertAll(x => x.ChampionStats.First(x => x.PerticipantId == YourId).Gold);
            var opponentGoldData = TimeLine.Value.StatPerMinute.ConvertAll(x => x.ChampionStats.First(x => x.PerticipantId == OpponentId).Gold);
            switch (GraphContentSelected.Value)
            {
                case GraphContent.TotalGold:
                    GraphData.Value = (yourGoldData.ConvertAll(x => x.Total), opponentGoldData.ConvertAll(x => x.Total));
                    break;
                case GraphContent.HavingGold:
                    GraphData.Value = (yourGoldData.ConvertAll(x => x.Having), opponentGoldData.ConvertAll(x => x.Having));
                    break;
                case GraphContent.CreapScore:
                    GraphData.Value = (
                        yourGoldData.ConvertAll(x => x.JungleMonstersKilled + x.MinionsKilled),
                        opponentGoldData.ConvertAll(x => x.JungleMonstersKilled + x.MinionsKilled));
                    break;
            }
        }

        public void OnTimeLineContentSelect()
        {
            if (TimeLine.Value == null)
            {
                return;
            }
            YourEventFrames.Value = CreateViewTimeLineEvents(YourId);
            OpponentEventFrames.Value = CreateViewTimeLineEvents(OpponentId);
        }

        private List<ViewTimeLineEventEntity> CreateViewTimeLineEvents(int participantId)
        {
            switch (EventTypeSelected.Value)
            {
                case EventType.Kill:
                    if (YourId == participantId)
                    {
                        if (_yourChampionKillEventFramesCash == null)
                        {
                            _yourChampionKillEventFramesCash = CreateKillEventFrames(participantId);
                        }
                        return _yourChampionKillEventFramesCash;
                    }
                    else
                    {
                        if (_opponentChampionKillEventFramesCash == null)
                        {
                            _opponentChampionKillEventFramesCash = CreateKillEventFrames(participantId);
                        }
                        return _opponentChampionKillEventFramesCash;
                    }
                case EventType.Purchase:
                    if (YourId == participantId)
                    {
                        if (_yourPurchaseEventFramesCash == null)
                        {
                            _yourPurchaseEventFramesCash = CreatePurchaseEventFrames(participantId);
                        }
                        return _yourPurchaseEventFramesCash;
                    }
                    else
                    {
                        if (_opponentPurchaseEventFramesCash == null)
                        {
                            _opponentPurchaseEventFramesCash = CreatePurchaseEventFrames(participantId);
                        }
                        return _opponentPurchaseEventFramesCash;
                    }
                default:
                    throw new NotImplementedException();
            }
        }

        private List<ViewTimeLineEventEntity> CreateKillEventFrames(int participantId)
        {
            var killEventFrames = new List<ViewTimeLineEventEntity>();
            var targetKillEvents = TimeLine.Value.ChampionKillEvents.Where(x => x.ParticipantId == participantId).ToList();
            for (var i = 0; i < targetKillEvents.Count; i++)
            {
                var killEvent = targetKillEvents[i];
                killEventFrames.Add(new(killEvent.TimeStamp, new() { killEvent.ParticipantId.ToString(), killEvent.VictimId.ToString() }));
                for (var j = 1; j < killEvent.MultiKillLength; j++)
                {
                    killEventFrames.Last().Params!.Add(targetKillEvents[++i].VictimId.ToString());
                }
            }
            return killEventFrames;
        }

        private List<ViewTimeLineEventEntity> CreatePurchaseEventFrames(int participantId)
        {
            var purchaseEventFrames = new List<ViewTimeLineEventEntity>();
            var targetParchaseEvents = TimeLine.Value.ItemEvents.Where(x => x.ParticipantId == participantId).ToList();
            for (var i = 0; i < targetParchaseEvents.Count; i++)
            {
                var purchaseEvent = targetParchaseEvents[i];
                var lastEvent = purchaseEventFrames.LastOrDefault();
                if (lastEvent != null &&
                    purchaseEvent.TimeStamp.TotalSeconds <= lastEvent.TimeStamp.TotalSeconds + 10)
                {
                    lastEvent.Params.Add(purchaseEvent.ItemId.ToString());
                }
                else
                {
                    purchaseEventFrames.Add(new(purchaseEvent.TimeStamp, new() { purchaseEvent.ItemId.ToString() }));
                }
            }
            return purchaseEventFrames;
        }

        public void OnDispose()
        {
            TimeLine.Dispose();
            Match.Dispose();
            GraphData.Dispose();
            YourEventFrames.Dispose();
            OpponentEventFrames.Dispose();
            GraphContentSelected.Dispose();
            EventTypeSelected.Dispose();
            YourChampion = null;
            OpponentChampion = null;
            IsInitialized = false;
        }
    }
}
