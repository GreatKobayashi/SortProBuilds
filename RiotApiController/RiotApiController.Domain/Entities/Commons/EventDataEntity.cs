namespace RiotApiController.Domain.Entities.Commons
{
    public class EventDataEntity
    {
        public TimeSpan Time { get; set; }
        public Dictionary<string, string> EventData { get; set; } = new Dictionary<string, string>();

        public EventDataEntity(TimeSpan time)
        {
            Time = time;
        }
    }
}
