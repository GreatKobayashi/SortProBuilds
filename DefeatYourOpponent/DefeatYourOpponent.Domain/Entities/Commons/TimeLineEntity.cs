namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class TimeLineEntity
    {
        public static string ParticipantIdKey { get; } = "ParticipantId";
        public static string TotalGoldKey { get; } = "TotalGold";
        public static string PurchaseKey { get; } = "ItemId";
        public static string KillerKey { get; } = "KillerId";
        public static string VictimKey { get; } = "VictimId";
        public static string AssistKey { get; } = "AssistingParticipantIds";

        public List<EventDataEntity> PurchaseData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> GoldData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> KillData { get; set; } = new List<EventDataEntity>();

        public int[] GetTotalGoldChanges(string participantId)
        {
            var totalGoldEvent = GoldData.Where(x => x.EventData[ParticipantIdKey] == participantId).Select(x => x.EventData[TotalGoldKey]).ToArray();
            return Array.ConvertAll(totalGoldEvent, int.Parse);
        }
    }
}
