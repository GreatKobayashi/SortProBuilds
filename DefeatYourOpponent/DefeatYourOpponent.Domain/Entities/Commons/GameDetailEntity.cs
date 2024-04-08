namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class GameDetailEntity
    {
        public TimeLineEntity TimeLine { get; }
        public List<PlayerDataEntity> PlayerDataList { get; }

        public GameDetailEntity(TimeLineEntity timeLine, List<PlayerDataEntity> playerDataList)
        {
            TimeLine = timeLine;
            PlayerDataList = playerDataList;
        }
    }
}
