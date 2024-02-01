using Microsoft.AspNetCore.Mvc;
using RiotApiController.Domain.Repositories;
using RiotApiController.Infrastructure;
using RiotSharp;
using RiotSharp.Misc;
using System.Text.Json;

namespace RiotApiController.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiotApiController : ControllerBase
    {
        private string _apiKey = "RGAPI-7757f625-5630-414e-a6ec-c7cf76fadaef";

        // Duster PuuID
        private string _puuId = "1YJ96H5Z9Gy7XVs-KlceM--D_GdxTmReFllNRQjdZPMNrcnJDTnBM3_c9SJ9oenNQTJL4i5vtbI7tg";

        private GameResultRepository _gameResultRepository;

        public RiotApiController()
        {
            var api = RiotApi.GetDevelopmentInstance(_apiKey);
            _gameResultRepository = new GameResultRepository(Factories.CreateMatchResultRepository(api));
        }

        [HttpGet]
        public async Task<string> GetMatchData()
        {
            try
            {
                var testTag = new Dictionary<string, string>()
                {
                    { "Position", "MIDDLE" }
                };
                var gameList = await _gameResultRepository.GetMatchDataAsync(10, Region.Asia, _puuId, testTag);
                return JsonSerializer.Serialize(gameList);
            }
            catch (RiotSharpException)
            {
                throw;
            }
        }

        [HttpPost]
        public void PostAddPlayerData()
        {

        }
    }
}
