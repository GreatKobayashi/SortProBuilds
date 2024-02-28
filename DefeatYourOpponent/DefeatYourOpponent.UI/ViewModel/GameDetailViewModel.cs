using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Repositories;
using RiotSharp.Misc;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class GameDetailViewModel
    {
        private ITimeLineRepository _timeLineRepository;
        public TimeLineEntity? TimeLine { get; set; }

        public GameDetailViewModel(ITimeLineRepository timeLineRepository)
        {
            _timeLineRepository = timeLineRepository;
        }

        public void GetGameTimeLine(Region region, string gameId, int targetId, int opponentId)
        {
            //_timeLineRepository.GetTimeLineAsync(region, gameId, targetId, opponentId);
        }
    }
}
