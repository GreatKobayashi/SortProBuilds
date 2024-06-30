namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IApiKeyRepository
    {
        public Task<string> GetApiKey();
    }
}
