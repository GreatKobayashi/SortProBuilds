using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain.Helper;
using System.Text;

namespace DefeatYourOpponent.Infrastructure.Json
{
    public class ChampionsDataJson : IChampionsDataRepository
    {
        private ChampionsDataEntity _championsDataEntity;

        public ChampionsDataJson(string championsDataFilePath)
        {
            _championsDataEntity = JsonSerializerHelper.Deserialize<ChampionsDataEntity>(championsDataFilePath, FileAccess.Read);
        }

        public ChampionsDataEntity GetEntity()
        {
            return _championsDataEntity;
        }
    }
}
