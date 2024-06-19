namespace DefeatYourOpponent.Domain.Exceptions
{
    public class InternalException : Exception
    {
        public string ErrorCode { get; }

        public InternalException(string errorCode, Exception innnerException) : base(innnerException.Message, innnerException)
        {
            ErrorCode = errorCode;
        }

        public InternalException(string errorCode)
        {
            ErrorCode = errorCode;
        }
    }
}
