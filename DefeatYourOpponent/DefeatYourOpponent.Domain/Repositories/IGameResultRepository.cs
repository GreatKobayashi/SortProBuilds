using DefeatYourOpponent.Domain.Entities.Commons;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IGameResultRepository
    {
        public Task<List<GameResultEntity>> GetGameResultEntitiesAsync();
    }
}
