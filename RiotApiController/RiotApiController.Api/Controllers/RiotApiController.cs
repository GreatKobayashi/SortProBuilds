using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Entities;
using RiotApiController.Domain.Misc.Commons;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure;
using RiotSharp;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RiotApiController : ControllerBase
    {
        private string _apiKey = "RGAPI-c6c222ac-b393-49cd-a064-bae780a84d24";

        // Duster PuuID
        private string _puuId = "1YJ96H5Z9Gy7XVs-KlceM--D_GdxTmReFllNRQjdZPMNrcnJDTnBM3_c9SJ9oenNQTJL4i5vtbI7tg";

        private GameResultRepository _gameResultRepository;

        public RiotApiController()
        {
            var api = RiotApi.GetDevelopmentInstance(_apiKey);
            _gameResultRepository = new GameResultRepository(Factories.CreateGameResultRepository(api));
        }

        [Route("GetGameResult")]
        [HttpPost]
        public async Task<string> GetGameResultAsync(RiotApiGetGameResultRequestBody requestBody)
        {
            try
            {
                var puuid = await _gameResultRepository.GetPuuidAsync(requestBody.Region, requestBody.SummonerName);
                var gameList = await _gameResultRepository.GetGameResultAsync(10, requestBody.Region, puuid, requestBody.Tags);
                return JsonSerializer.Serialize(gameList);
            }
            catch (RiotSharpException)
            {
                throw;
            }
        }
    }
}
