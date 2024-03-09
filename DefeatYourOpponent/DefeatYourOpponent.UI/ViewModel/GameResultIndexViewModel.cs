using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Exceptions;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain.Misc;
using RiotSharp;
using RiotSharp.Misc;
using System.Net;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class GameResultIndexViewModel
    {
        private readonly IGameResultRepository _gameResultRepository;
        private readonly ChampionsDataEntity _championsDataEntity;

        public string DefaultInputedChampionName { get; } = "All Champion";

        public List<GameResultEntity> GameResultList { get; private set; } = new List<GameResultEntity>();

        public GameResultIndexViewModel(IGameResultRepository gameResultRepository,
            ChampionsDataEntity championsDataEntity)
        {
            _gameResultRepository = gameResultRepository;
            _championsDataEntity = championsDataEntity;
        }

        public async Task GetGameResultEntitiesBySummonerNameAsync(
            int regionNum, string? enteredSummonerName, TagEntity tags, int count)
        {
            GameResultList.Clear();

            if (regionNum < 0)
            {
                throw new InternalException("地域未選択");
            }
            var region = (Region)regionNum;
            if (!string.IsNullOrEmpty(enteredSummonerName))
            {
                GameResultList = await _gameResultRepository.GetGameResultEntitiesAsync(region, enteredSummonerName, tags, count);
                GameResultList.ForEach(result => result.TargetPlayerData.Items.RemoveAll(id => id == 0));

                if (GameResultList.Count < count)
                {
                    throw new RiotSharpException("Few data", new HttpStatusCode());
                }
            }
            else
            {
                throw new InternalException("サモナー名未入力");
            }
        }

        public TagEntity GetTags(int queueType, int position, string championName)
        {
            var tags = new TagEntity();

            if (queueType != 0)
            {
                tags.QueueType = queueType;
            }
            if (position != 0)
            {
                tags.Position = (TeamPosition)position;
            }
            if (!string.IsNullOrEmpty(championName) && championName != DefaultInputedChampionName)
            {
                if (_championsDataEntity.Data.ContainsKey(championName))
                {
                    tags.Champion = championName;
                }
                else
                {
                    throw new InternalException("一致するチャンピオン名なし");
                }
            }

            return tags;
        }
    }
}
