using DefeatYourOpponent.Domain.Repositories;
using DefeatYourOpponent.Infrastructure.WebApi;
using RiotApiController.Domain.Entities;
using RiotApiController.Infrastructure.Json;
using RiotSharp;

namespace RiotApiController.Infrastructure
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
    }
}
