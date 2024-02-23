using RiotApiController.Domain.Misc;
using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class GameResultEntity
    {
        public int QueueId { get; }
        public string Champion { get; }
        public bool Win { get; }
        // RuneEntity
        //Participants
        public Position Position { get; }
        public string OpponentChampion { get; }
        public List<long> Items { get; }
        public long Ward { get; }
        public long Kill { get; }
        public long Death { get; }
        public long Assist { get; }

        public GameResultEntity(int queueId, string champion, bool win, string position, string opponentChampion, List<long> items,
            long ward, long kill, long death, long assist)
        {
            QueueId = queueId;
            Champion = champion;
            Win = win;
            Position = Enum.Parse<Position>(position);
            OpponentChampion = opponentChampion;
            Ward = ward;
            Items = items;
            Kill = kill;
            Death = death;
            Assist = assist;
        }

        [JsonConstructor]
        public GameResultEntity(
            int queueId,
            string champion,
            bool win,
            Position position,
            string opponentChampion,
            List<long> items,
            long ward,
            long kill,
            long death,
            long assist)
        {
            QueueId = queueId;
            Champion = champion;
            Win = win;
            Position = position;
            OpponentChampion = opponentChampion;
            Ward = ward;
            Items = items;
            Kill = kill;
            Death = death;
            Assist = assist;
        }
    }
}
