using DefeatYourOpponent.Domain;
using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Exceptions;
using DefeatYourOpponent.Domain.Logics;
using DefeatYourOpponent.Domain.Repositories;
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

        public async Task<List<GameResultEntity>> GetGameResultEntitiesAsync(
            string summonerName, TagEntity tags, int count)
        {
            // ★TODO: tag, Region選択の実装後反映
            var testRequest = new RiotApiGetGameResultRequestBody(Region.Jp, summonerName, tags, count);

            HttpResponseMessage response;
            try
            {
                response = await _httpClient.PostAsJsonAsync(
                    Shared.SettingEntity.RiotControllerSetting.GetGameResultUrl, testRequest);
            }
            catch (Exception ex)
            {
                throw new InternalException("サーバー接続失敗", ex);
            }

            return ResponseConverter.Convert<List<GameResultEntity>>(response);
        }
    }
}
