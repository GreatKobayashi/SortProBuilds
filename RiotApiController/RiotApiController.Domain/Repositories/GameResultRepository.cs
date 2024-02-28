using RiotApiController.Domain.Entities.Commons;
using RiotSharp.Endpoints.AccountEndpoint.Enums;
using RiotSharp.Endpoints.MatchEndpoint.Enums;
using RiotSharp.Misc;
using static System.Net.Mime.MediaTypeNames;

namespace RiotApiController.Domain.Repositories
{
    public class GameResultRepository
    {
        private IGameResultRepository _gameResultRepository;

        public GameResultRepository(IGameResultRepository gameResultRepository)
        {
            _gameResultRepository = gameResultRepository;
        }

        public async Task<List<GameResultEntity>> GetGameResultAsync(long count, Region region, string puuId, TagEntity tags)
        {
            var matchedGameList = new List<GameResultEntity>();
            var start = 0;
            do
            {
                var gameList = await _gameResultRepository.GetGameResultAsync(start, count, region, puuId);
                foreach (var game in gameList)
                {
                    if (tags.IsMatch(game))
                    {
                        matchedGameList.Add(game);
                    }
                }
                start += 10;
            }
            while (matchedGameList.Count < count && start / 10 < Shared.SettingEntity.MaxTryCount);

            return matchedGameList.Take((int)count).ToList();
        }

        public async Task<string> GetPuuidAsync(Region region, string summonerName)
        {
            return await _gameResultRepository.GetPuuidAsync(region, summonerName);
        }

        public async Task<TimeLineEntity> GetTimeLine(Region region, string gameId, int targetId, int opponentId)
        {
            return await _gameResultRepository.GetTimeLine(region, gameId, targetId, opponentId);
        }
    }
}
