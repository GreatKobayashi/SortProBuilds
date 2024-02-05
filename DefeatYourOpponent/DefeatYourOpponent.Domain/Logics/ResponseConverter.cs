using RiotApiController.Domain.Helper;
using System.Text.Json;

namespace DefeatYourOpponent.Domain.Logics
{
    public static class ResponseConverter
    {
        public static Type Convert<Type>(HttpResponseMessage response)
        {
            try
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
#pragma warning disable CS8603
                return JsonSerializer.Deserialize<Type>(responseBody);
#pragma warning restore CS8603
            }
            catch (Exception ex)
            {
                throw new Exception("HTTPレスポンス不正", ex);
            }
        }
    }
}
