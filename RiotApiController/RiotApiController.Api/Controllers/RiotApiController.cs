using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Entities.Commons;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure;
using RiotSharp;
using RiotSharp.Misc;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RiotApiController : ControllerBase
    {
        private string _apiKey = "RGAPI-41d0978e-71b7-4fc0-8039-a7217c9bb840";

        private GameResultRepository _gameResultRepository;

        public RiotApiController()
        {
            var api = RiotApi.GetDevelopmentInstance(_apiKey);
            _gameResultRepository = new GameResultRepository(Factories.CreateGameResultRepository(api));
        }

        [Route("PostTagsTakeGameResults")]
        [HttpPost]
        public async Task<string> PostTakeGameResultAsync(RiotApiGetGameResultRequestBody requestBody)
        {
            try
            {
                var puuid = await _gameResultRepository.GetPuuidAsync(requestBody.Region, requestBody.SummonerName);
                var gameList = await _gameResultRepository.GetGameResultAsync(10, requestBody.Region, puuid, requestBody.Tags);
                return JsonSerializer.Serialize(gameList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("GetGameDetail/{matchId}")]
        [HttpGet]
        public async Task<string> GetGameDetailAsync([FromQuery] Region region, string matchId, [FromQuery] int targetId, [FromQuery] int opponentId)
        {
            try
            {
                var gameDetail = await _gameResultRepository.GetGetGameDetailAsync(region, matchId, targetId, opponentId);
                return JsonSerializer.Serialize(gameDetail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
