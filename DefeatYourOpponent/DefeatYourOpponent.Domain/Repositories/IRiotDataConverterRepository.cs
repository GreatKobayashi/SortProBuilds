using DefeatYourOpponent.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IRiotDataConverterRepository
    {
        public string QueueIdToString(int queueId);
        public string WinToString(bool win);
        public List<QueueTypeEntity> GetSelectableQueueType(bool includeSpecialGame);
    }
}
