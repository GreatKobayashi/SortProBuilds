namespace DefeatYourOpponent.Domain.Entities.Commons
{
    public class GameResultEntity
    {
        public long Queue { get; }
        public string Champion { get; }
        public bool Win { get; }
        // RuneEntity
        //Participants
        public string Position { get; }
        public string OpponentChampion { get; }
        public List<long> Items { get; }
        public long Kill { get; }
        public long Death { get; }
        public long Assist { get; }

        public GameResultEntity(long queue, string champion, bool win, string position, string opponentChampion, List<long> items, long kill,
            long death, long assist)
        {
            Queue = queue;
            Champion = champion;
            Win = win;
            Position = position;
            OpponentChampion = opponentChampion;
            Items = items;
            Kill = kill;
            Death = death;
            Assist = assist;
        }
    }
}
