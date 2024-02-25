using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Entities.Commons;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure;
using RiotSharp;
using System.Net;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class RiotApiController : ControllerBase
    {
        private string _apiKey = "RGAPI-c79e22ec-3cd0-4ffa-8b7a-8ae5a60d9ffd";

        private GameResultRepository _gameResultRepository;

        public RiotApiController()
        {
            var api = RiotApi.GetDevelopmentInstance(_apiKey);
            _gameResultRepository = new GameResultRepository(Factories.CreateGameResultRepository(api));
        }

        [Route("PostTakeGameResult")]
        [HttpPost]
        public async Task<string> PostTakeGameResultAsync(RiotApiGetGameResultRequestBody requestBody)
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
            catch (Exception ex)
            {
                throw new RiotSharpException(ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
