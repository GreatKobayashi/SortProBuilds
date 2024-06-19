using DefeatYourOpponent.Domain.Exceptions;
using DefeatYourOpponent.Domain.Misc;
using RiotApiWrapper.Exceptions;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IErrorMessageConverterRepository
    {
        public string GetMessage(Language language, RiotApiException exception);
        public string GetMessage(Language language, InternalException exception);
    }
}
