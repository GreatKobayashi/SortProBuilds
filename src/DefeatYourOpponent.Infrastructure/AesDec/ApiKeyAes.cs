using DefeatYourOpponent.Domain.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace DefeatYourOpponent.Infrastructure.AesDec
{
    public class ApiKeyAes : IApiKeyRepository
    {
        private byte[] _aesKey = Encoding.UTF8.GetBytes("Here is key string!");
        private readonly string _apiKeyFilePath;

        public ApiKeyAes(string apiKeyFilePath)
        {
            _apiKeyFilePath = apiKeyFilePath;
        }

        public async Task<string> GetApiKey()
        {
            var cipherByte = Convert.FromBase64String(File.ReadAllText(_apiKeyFilePath));
            var iv = cipherByte[..16];

            using (var aes = Aes.Create())
            {
                var decryptor = aes.CreateDecryptor(_aesKey, iv);
                using (var ms = new MemoryStream())
                {
                    await using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    await using (var bw = new BinaryWriter(cs))
                    {
                        bw.Write(cipherByte, iv.Length, cipherByte.Length - iv.Length);
                    }
                    var bytes = ms.ToArray();
                    return Encoding.Default.GetString(bytes);
                }
            }
        }
    }
}
