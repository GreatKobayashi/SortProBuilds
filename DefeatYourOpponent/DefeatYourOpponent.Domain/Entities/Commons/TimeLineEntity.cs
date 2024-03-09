namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class TimeLineEntity
    {
        private static readonly string _participantIdKey = "ParticipantId";
        private static readonly string _totalGoldKey = "TotalGold";

        public List<EventDataEntity> PurchaseData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> GoldData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> KillData { get; set; } = new List<EventDataEntity>();

        public int[] GetTargetTotalGoldChanges(string targetId)
        {
            var totalGoldEvent = GoldData.Where(x => x.EventData[_participantIdKey] == targetId).Select(x => x.EventData[_totalGoldKey]).ToArray();
            return Array.ConvertAll(totalGoldEvent, int.Parse);
        }
    }
}
