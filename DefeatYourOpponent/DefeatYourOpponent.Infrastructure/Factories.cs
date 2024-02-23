using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Logics;
using DefeatYourOpponent.Domain.Repositories;
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

        public static IGameResultRepository CreateGameResultRepository()
        {
            return new RiotControllerWebApi();
        }

        public static IErrorMessageConverterRepository CreateErrorMessageConverterRespository(
            string riotApiErrorMessagelistFilePath, string internalErrorMessagelistFilePath)
        {
            return new ErrorMessageConverterJson(riotApiErrorMessagelistFilePath, internalErrorMessagelistFilePath);
        }

        public static IChampionsDataRepository CreateChampionsDataRepository(string championsDataFilePath)
        {
            return new ChampionsDataJson(championsDataFilePath);
        }

        public static IRiotDataConverterRepository CreateRiotDataConverterRepository(
            string queueIdListFilePath)
        {
            return new RiotDataConverterJson(queueIdListFilePath);
        }
    }
}
