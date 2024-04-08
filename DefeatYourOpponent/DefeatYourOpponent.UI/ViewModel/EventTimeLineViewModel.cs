using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Misc;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class EventTimeLineViewModel
    {
        private static readonly int _defaultY = 20;
        private static readonly int _imageHeight = 60;
        public int MaxVerticalDisplay { get; private set; } = 1;

        public Dictionary<TimeSpan, List<string>> GetPurchaseTimeline(List<EventDataEntity> purchaseData, int participantId)
        {
            return GetPurchaseTimeline(purchaseData, participantId.ToString());
        }

        public Dictionary<TimeSpan, List<string>> GetPurchaseTimeline(List<EventDataEntity> purchaseData, string participantId)
        {
            var purchaseKey = TimeLineEntity.PurchaseKey;
            var purchaseEvents = purchaseData.Where(x => x.EventData[TimeLineEntity.ParticipantIdKey] == participantId);

            var purchaseTimeline = new Dictionary<TimeSpan, List<string>>();
            foreach (var purchaseEvent in purchaseEvents)
            {
                if (purchaseTimeline.TryGetValue(purchaseEvent.Time, out _))
                {
                    purchaseTimeline[purchaseEvent.Time].Add(purchaseEvent.EventData.First(x => x.Key == purchaseKey).Value);
                }
                else if (purchaseTimeline.Count > 0 && purchaseTimeline.Last().Key.TotalSeconds > purchaseEvent.Time.TotalSeconds - 10)
                {
                    purchaseTimeline.Last().Value.Add(purchaseEvent.EventData.First(x => x.Key == purchaseKey).Value);
                }
                else
                {
                    purchaseTimeline.Add(purchaseEvent.Time, new List<string>() { purchaseEvent.EventData.First(x => x.Key == purchaseKey).Value });
                }
            }
            return purchaseTimeline;
        }

        public Dictionary<TimeSpan, List<string>> GetKillTimeline(List<EventDataEntity> killData, int participantId)
        {
            return GetKillTimeline(killData, participantId.ToString());
        }

        private bool AssistsContains(EventDataEntity killEvent, string participantId)
        {
            if (killEvent.EventData.TryGetValue(TimeLineEntity.AssistKey, out var assists))
            {
                return assists.Contains(participantId);
            }
            return false;
        }

        public Dictionary<TimeSpan, List<string>> GetKillTimeline(List<EventDataEntity> killData, string participantId)
        {
            var killEvents = killData.Where(x =>
                x.EventData[TimeLineEntity.KillerKey] == participantId ||
                x.EventData[TimeLineEntity.VictimKey] == participantId ||
                AssistsContains(x, participantId)).ToList();

            var killTimeLine = new Dictionary<TimeSpan, List<string>>();
            foreach (var killEvent in killEvents)
            {
                killTimeLine.Add(killEvent.Time, new List<string>() { killEvent.EventData.First(x => x.Key == TimeLineEntity.KillerKey).Value });
                killEvent.EventData.TryGetValue(TimeLineEntity.AssistKey, out var assists);
                foreach (var assist in assists?.Split(',') ?? [])
                {
                    killTimeLine[killEvent.Time].Add(assist);
                }
                killTimeLine[killEvent.Time].Add(killEvent.EventData.First(x => x.Key == TimeLineEntity.VictimKey).Value);
            }

            return killTimeLine;
        }

        public List<TimeSpan> GetEventTimespan(
            Dictionary<TimeSpan, List<string>> targetEventTimes,
            Dictionary<TimeSpan, List<string>> opponentEventTimes)
        {
            var purchaseEventTimes = targetEventTimes
                .Concat(opponentEventTimes).GroupBy(x => x.Key).ToDictionary(x => x.Key, x => x.FirstOrDefault().Value);
            var purchaseEventTimelineTicks = purchaseEventTimes.Keys.ToList();

            var tickMinute = 0;
            var tickList = new List<TimeSpan>();
            while (purchaseEventTimelineTicks.Max().TotalMinutes > tickMinute)
            {
                tickList.Add(new TimeSpan(0, tickMinute, 0));
                tickMinute += 5;
            }

            return tickList;
        }

        public List<ImagePostionEntity> GetImagePositionList(Dictionary<TimeSpan, List<string>> eventDataList, EventType eventType)
        {
            var imagePostionList = new List<ImagePostionEntity>();
            foreach (var eventData in eventDataList)
            {
                var eventHappenedTime = eventData.Key.TotalSeconds;
                var imageCount = eventData.Value.Count;
                var recentEvents = imagePostionList.Where(x => x.EndX > eventHappenedTime).ToList();
                if (recentEvents.Any())
                {
                    var y = 0;
                    while (true)
                    {
                        if (!recentEvents.Any(x => x.Y == _defaultY + y))
                        {
                            int varticalDisplay = y / _imageHeight + 1;
                            if (MaxVerticalDisplay < varticalDisplay)
                            {
                                MaxVerticalDisplay = varticalDisplay;
                            }
                            imagePostionList
                                .Add(new ImagePostionEntity(eventHappenedTime, eventHappenedTime + GetTotalImageWidth(imageCount, eventType), _defaultY + y));
                            break;
                        }
                        y += _imageHeight;
                    }
                }
                else
                {
                    imagePostionList
                        .Add(new ImagePostionEntity(eventHappenedTime, eventHappenedTime + GetTotalImageWidth(imageCount, eventType), _defaultY));
                }
            }

            return imagePostionList;
        }

        private int GetTotalImageWidth(int imageCount, EventType eventType)
        {
            switch (eventType)
            {
                case EventType.PURCHASE:
                    return 55 * imageCount;
                case EventType.KILL:
                    return 105 + Shared.SettingEntity.KillIconWidth + (imageCount - 2) * Shared.SettingEntity.AssistChampionImageWidth;
                default:
                    throw new Exception("EventType不正");
            }
        }
    }
}
