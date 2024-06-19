using System.Text;
using System.Text.Json;

namespace RiotApiController.Domain.Helper
{
    public static class JsonSerializerHelper
    {
        public static T Deserialize<T>(string filePath, FileAccess fileAccess)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, fileAccess, FileShare.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream, Encoding.UTF8))
                {
#pragma warning disable CS8603
                    return JsonSerializer.Deserialize<T>(reader.ReadToEnd(), options);
#pragma warning restore CS8603
                }
            }
        }

        public static T Deserialize<T>(string serializedStr)
        {
            try
            {
#pragma warning disable CS8603
                return JsonSerializer.Deserialize<T>(serializedStr);
#pragma warning restore CS8603
            }
            catch (Exception ex)
            {
                throw new Exception("デシリアライズ失敗", ex);
            }
        }
    }
}
