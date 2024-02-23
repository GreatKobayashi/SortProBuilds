using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain.Misc;
using RiotSharp;
using System.Net;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class GameResultIndexViewModel
    {
        private readonly IGameResultRepository _gameResultRepository;
        private readonly ChampionsDataEntity _championsDataEntity;
        private static readonly string _championImagesDirectoryPath = "images/champion/tiles/";
        private static readonly string _itemImagesDirectoryPath = "images/item/";

        public List<GameResultEntity> GameResultList { get; private set; } = new List<GameResultEntity>();

        public GameResultIndexViewModel(IGameResultRepository gameResultRepository,
            ChampionsDataEntity championsDataEntity)
        {
            _gameResultRepository = gameResultRepository;
            _championsDataEntity = championsDataEntity;
        }

        public async Task GetGameResultEntitiesBySummonerName(
            string? enteredSummonerName, TagEntity tags, int count)
        {
            GameResultList.Clear();

            if (!string.IsNullOrEmpty(enteredSummonerName))
            {
                GameResultList = await _gameResultRepository.GetGameResultEntitiesAsync(enteredSummonerName, tags, count);
                GameResultList.ForEach(result => result.Items.RemoveAll(id => id == 0));

                if (GameResultList.Count < count)
                {
                    throw new RiotSharpException("Few data", new HttpStatusCode());
                }
            }
            else
            {
                throw new RiotSharpException("Null Summoner name", new HttpStatusCode());
            }
        }

        public string GetChampionImagePath(string championName)
        {
            return $"{_championImagesDirectoryPath}{championName}_0.jpg";
        }

        public string GetItemImagePath(long id)
        {
            return $"{_itemImagesDirectoryPath}{id}.png";
        }

        public TagEntity GetTags(int queueType, int position, int champion)
        {
            var tags = new TagEntity();

            if (queueType != 0)
            {
                tags.QueType = queueType;
            }
            if (position != 0)
            {
                tags.Position = (Position)position;
            }
            if (champion != 0)
            {
                tags.Champion = _championsDataEntity.Data.First(x => x.Value.Key == champion.ToString()).Value.Id;
            }

            return tags;
        }
    }
}
