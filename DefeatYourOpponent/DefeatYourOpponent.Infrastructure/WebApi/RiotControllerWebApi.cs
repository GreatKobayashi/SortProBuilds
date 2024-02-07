using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Logics;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain;
using RiotApiController.Domain.Misc;
using RiotSharp.Misc;
using System.Net.Http.Json;

namespace DefeatYourOpponent.Infrastructure.WebApi
{
    public class RiotControllerWebApi : IGameResultRepository
    {
        private HttpClient _httpClient;

        public RiotControllerWebApi()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(Shared.SettingEntity.RiotControllerSetting.BaseUrl)
            };
        }

        public async Task<List<GameResultEntity>> GetGameResultEntitiesAsync(string summonerName, Dictionary<string, string> tags)
        {
            var testRequest = new RiotApiGetGameResultRequestBody()
            {
                Region = Region.Jp,
                SummonerName = summonerName,
                Tags = tags
            };

            var response = await _httpClient.PostAsJsonAsync(
                Shared.SettingEntity.RiotControllerSetting.GetGameResultUrl, testRequest);

            return ResponseConverter.Convert<List<GameResultEntity>>(response);
        }
    }
}
