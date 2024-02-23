using RiotApiController.Domain.Misc;

namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class TagEntity
    {
        public string? Champion { get; set; }
        public bool? Win { get; set; }
        public Position? Position { get; set; }
        public int? QueType { get; set; }

        public bool IsMatch(GameResultEntity gameResultEntity)
        {
            if (!string.IsNullOrEmpty(Champion) && gameResultEntity.Champion != Champion ||
                Win != null && gameResultEntity.Win != Win ||
                Position != null && gameResultEntity.Position != Position)
            {
                return false;
            }

            return true;
        }
    }
}
