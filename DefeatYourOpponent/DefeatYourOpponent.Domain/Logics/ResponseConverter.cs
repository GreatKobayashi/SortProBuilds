using DefeatYourOpponent.Domain.Entities.Commons;
using RiotApiController.Domain.Helper;
using RiotSharp;

namespace DefeatYourOpponent.Domain.Logics
{
    public static class ResponseConverter
    {
        public static Type Convert<Type>(HttpResponseMessage response)
        {
            var responseBody = response.Content.ReadAsStringAsync().Result;
            try
            {
                response.EnsureSuccessStatusCode();
                return JsonSerializerHelper.Deserialize<Type>(responseBody);
            }
            catch
            {
                var errorResponseBody = JsonSerializerHelper.Deserialize<RiotApiErrorResponseBody>(responseBody);
                throw new RiotSharpException(errorResponseBody.Message, errorResponseBody.HttpStatusCode);
            }
        }
    }
}
