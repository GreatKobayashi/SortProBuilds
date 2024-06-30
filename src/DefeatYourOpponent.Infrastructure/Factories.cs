using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Repositories;
using DefeatYourOpponent.Infrastructure.AesDec;
using DefeatYourOpponent.Infrastructure.Json;
using DefeatYourOpponent.Infrastructure.WebApi;

namespace DefeatYourOpponent.Infrastructure
{
    public static class Factories
    {
        public static ISettingFileRepository CreateSettingFileRepository()
        {
            return new SettingFileJson();
        }

        public static IApiRepository CreateApiRepository(string apiKey)
        {
            return new RiotApiWrapperApi(apiKey);
        }

        public static IErrorMessageConverterRepository CreateErrorMessageConverterRespository(
            string riotApiErrorMessagelistFilePath, string internalErrorMessagelistFilePath)
        {
            return new ErrorMessageConverterJson(riotApiErrorMessagelistFilePath, internalErrorMessagelistFilePath);
        }

        public static IApiKeyRepository CreateApiKeyRepository(string apiKeyFilePath)
        {
            return new ApiKeyAes(apiKeyFilePath);
        }
    }
}
