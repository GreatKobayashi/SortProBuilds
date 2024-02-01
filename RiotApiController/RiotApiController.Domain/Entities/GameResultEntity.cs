using RiotSharp.Misc;

namespace RiotApiController.Domain.Entities
{
    public class GameResultEntity
    {
        public string Champion { get; }
        public bool Win { get; }
        // RuneEntity
        //Items ItemEntity
        //SameLaneEnemy
        //Participants
        public string Position { get; }

        public GameResultEntity(string champion, bool win, string position)
        {
            Champion = champion;
            Win = win;
            Position = position;
        }
    }
}
