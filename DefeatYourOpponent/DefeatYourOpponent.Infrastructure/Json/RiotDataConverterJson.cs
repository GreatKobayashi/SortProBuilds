using DefeatYourOpponent.Domain.Entities;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain.Helper;
using RiotApiController.Domain.Misc;

namespace DefeatYourOpponent.Domain.Logics
{
    public class RiotDataConverterJson : IRiotDataConverterRepository
    {
        private List<QueueTypeEntity> _queueTypeList;

        public RiotDataConverterJson(string queueTypeListFilePath)
        {
            _queueTypeList = JsonSerializerHelper.Deserialize<List<QueueTypeEntity>>(queueTypeListFilePath, FileAccess.Read);
        }

        public string QueueIdToString(int queueId)
        {
            return _queueTypeList.First(x => x.QueueId == queueId).Description;
        }

        public string WinToString(bool win)
        {
            if (win)
            {
                return "WIN";
            }
            else
            {
                return "LOSE";
            }
        }

        public List<QueueTypeEntity> GetSelectableQueueType(bool includeSpecialGame)
        {
            if (includeSpecialGame)
            {
                return _queueTypeList.FindAll(x => x.Notes == null && x.Description != null);
            }
            return _queueTypeList.FindAll(x => x.QueueId == 420 || x.QueueId == 440 || x.QueueId == 450 || x.QueueId == 490 );
        }
    }
}
