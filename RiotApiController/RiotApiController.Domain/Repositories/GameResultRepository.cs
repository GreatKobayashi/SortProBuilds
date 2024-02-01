using RiotApiController.Domain.Entities;
using RiotSharp.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotApiController.Domain.Repositories
{
    public class GameResultRepository
    {
        private IGameResultRepository _matchResultRepository;

        public GameResultRepository(IGameResultRepository matchResultRepository)
        {
            _matchResultRepository = matchResultRepository;
        }

        public async Task<List<GameResultEntity>> GetMatchDataAsync(long count, Region region, string puuId, Dictionary<string, string> tagKeyAndValuePairs)
        {
            var matchList = await _matchResultRepository.GetMatchDataAsync(count, region, puuId);
            var tagEntity = new TagEntity(tagKeyAndValuePairs);

            var matchedGameList = new List<GameResultEntity>();
            foreach (var match in matchList)
            {
                if (tagEntity.IsMatch(match))
                {
                    matchedGameList.Add(match);
                }
            }
            return matchedGameList;
        }
    }
}
