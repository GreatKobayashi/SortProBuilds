using RiotApiWrapper.Entities;
using RiotApiWrapper.Misc;

namespace DefeatYourOpponent.Domain.Entities
{
    public class SerchTagEntity
    {
        public ChampionEntity? Champion { get; set; }
        public bool? Win { get; set; }
        public Position? Position { get; set; }
        public QueueType? QueueType { get; set; }
    }
}
