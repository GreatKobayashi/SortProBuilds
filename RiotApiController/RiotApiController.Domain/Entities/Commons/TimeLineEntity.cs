namespace RiotApiController.Domain.Entities.Commons
{
    public class TimeLineEntity
    {
        public List<EventDataEntity> PurchaseData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> GoldData { get; set; } = new List<EventDataEntity>();
        public List<EventDataEntity> KillData { get; set; } = new List<EventDataEntity>();
    }
}
