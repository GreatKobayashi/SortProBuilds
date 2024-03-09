using RiotApiController.Domain.Misc;
using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class GameResultEntity
    {
        public string MatchId { get; }
        public int QueueId { get; }
        public int TargetId { get; }
        public int OpponentId { get; }
        public bool Win { get; }
        // RuneEntity
        //Participants
        public string OpponentChampion { get; }
        public PlayerDataEntity TargetPlayerData { get; }

        [JsonConstructor]
        public GameResultEntity(string matchId, int queueId, int targetId, int opponentId, bool win, string opponentChampion, PlayerDataEntity targetPlayerData)
        {
            MatchId = matchId;
            QueueId = queueId;
            TargetId = targetId;
            OpponentId = opponentId;
            Win = win;
            OpponentChampion = opponentChampion;
            TargetPlayerData = targetPlayerData;
        }
    }
}
