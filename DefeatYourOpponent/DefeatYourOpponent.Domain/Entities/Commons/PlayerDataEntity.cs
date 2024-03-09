using RiotApiController.Domain.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class PlayerDataEntity
    {
        public int ParticipantId { get; }
        public string Champion { get; }
        public TeamPosition Position { get; }
        public List<int> Items { get; }
        public int Ward { get; }
        public int Kill { get; }
        public int Death { get; }
        public int Assist { get; }

        public PlayerDataEntity(int participantId, string champion, string position, List<long> items, long ward, long kill, long death, long assist)
            : this(participantId, champion, Enum.Parse<TeamPosition>(position), items.ConvertAll(x => (int)x), (int)ward, (int)kill, (int)death, (int)assist)
        {
        }

        [JsonConstructor]
        public PlayerDataEntity(int participantId, string champion, TeamPosition position, List<int> items, int ward, int kill, int death, int assist)
        {
            ParticipantId = participantId;
            Champion = champion;
            Position = position;
            Items = items;
            Ward = ward;
            Kill = kill;
            Death = death;
            Assist = assist;
        }
    }
}
