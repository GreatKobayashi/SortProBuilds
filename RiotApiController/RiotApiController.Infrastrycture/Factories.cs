using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure.Json;
using RiotApiController.Infrastructure.WebApi;
using RiotSharp;

namespace RiotApiController.Infrastructure
{
    public static class Factories
    {
        //public static IDatabaseAccessRepository CreateDatabaseAccessRepository()
        //{
        //    return new ScrapedMatchResultSqlite();
        //}

        public static ISettingFileRepository CreateSettingFileRepository()
        {
            return new SettingFileJson();
        }

        public static IGameResultRepository CreateGameResultRepository(RiotApi riotApi)
        {
            return new RiotApiWrapper(riotApi);
        }
    }
}
