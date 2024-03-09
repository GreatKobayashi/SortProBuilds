using DefeatYourOpponent.Domain.Entities.Commons;
using DefeatYourOpponent.Domain.Repositories;
using RiotSharp.Misc;

namespace DefeatYourOpponent.UI.ViewModel
{
    public class GameDetailViewModel
    {
        private ITimeLineRepository _timeLineRepository;

        public GameDetailViewModel(ITimeLineRepository timeLineRepository)
        {
            _timeLineRepository = timeLineRepository;
        }

        public async Task<GameDetailEntity> GetGameDetailAsync(Region region, string matchId, int targetId, int opponentId)
        {
            return await _timeLineRepository.GetGameDetailAsync(region, matchId, targetId, opponentId);
        }
    }
}
