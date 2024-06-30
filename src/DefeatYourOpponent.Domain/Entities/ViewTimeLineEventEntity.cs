namespace DefeatYourOpponent.Domain.Entities
{
    public class ViewTimeLineEventEntity
    {
        public ViewTimeLineEventEntity(TimeSpan timeStamp, List<string> @params)
        {
            TimeStamp = timeStamp;
            Params = @params;
        }

        public TimeSpan TimeStamp { get; set; }
        public List<string> Params { get; set; }
    }
}
