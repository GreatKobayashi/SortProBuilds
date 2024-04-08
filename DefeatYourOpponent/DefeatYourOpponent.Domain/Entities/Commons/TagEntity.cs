using DefeatYourOpponent.Domain.Misc;

namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class TagEntity
    {
        public string? Champion { get; set; }
        public bool? Win { get; set; }
        public TeamPosition? Position { get; set; }
        public int? QueueType { get; set; }

        public bool IsMatch(GameResultEntity gameResultEntity)
        {
            if (!string.IsNullOrEmpty(Champion) && gameResultEntity.TargetPlayerData.Champion != Champion ||
                Win != null && gameResultEntity.Win != Win ||
                Position != null && gameResultEntity.TargetPlayerData.Position != Position)
            {
                return false;
            }

            return true;
        }
    }
}
