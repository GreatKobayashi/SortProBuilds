using DefeatYourOpponent.Domain.Entities;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IRiotDataConverterRepository
    {
        public string QueueIdToString(int queueId);
        public string WinToString(bool win);
        public List<QueueTypeEntity> GetSelectableQueueType(bool includeSpecialGame);
    }
}
