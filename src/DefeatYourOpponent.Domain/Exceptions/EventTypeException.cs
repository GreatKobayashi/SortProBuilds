namespace DefeatYourOpponent.Domain.Exceptions
{
    public class EventTypeException : InternalException
    {
        private static readonly string _errorCode = "イベントタイプ指定不正";

        public EventTypeException() : base(_errorCode)
        {
        }
    }
}
