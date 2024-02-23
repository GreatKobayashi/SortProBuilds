using RiotSharp;
using System.Net;
using System.Text.Json.Serialization;

namespace RiotApiController.Domain.Entities.Commons
{
    [Serializable]
    public class RiotApiErrorResponseBody
    {
        public RiotApiErrorResponseBody(RiotSharpException riotSharpException)
        {
            HttpStatusCode = riotSharpException.HttpStatusCode;
            Message = riotSharpException.Message;
        }

        [JsonConstructor]
        public RiotApiErrorResponseBody(HttpStatusCode httpStatusCode, string message)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        public HttpStatusCode HttpStatusCode { get; }
        public string Message { get; }

        public RiotSharpException GetException()
        {
            return new RiotSharpException(Message, HttpStatusCode);
        }
    }
}
