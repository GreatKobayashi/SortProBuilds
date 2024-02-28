using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Entities.Commons;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure;
using RiotSharp;
using RiotSharp.Misc;
using System.Net;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RiotApiController : ControllerBase
    {
        private string _apiKey = "RGAPI-24b3a057-7a51-468a-8bfe-5caf936e655f";

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

        [Route("GetTimeLine/{gameId}")]
        [HttpGet]
        public async Task<string> GetTimeLineAsync([FromQuery] Region region, string gameId, [FromQuery] int targetId, [FromQuery] int opponentId)
        {
            try
            {
                var timeLine = await _gameResultRepository.GetTimeLine(region, gameId, targetId, opponentId);
                return JsonSerializer.Serialize(timeLine);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
