using DefeatYourOpponent.Domain.Exceptions;
using RiotSharp;
using RiotSharp.Misc;

namespace DefeatYourOpponent.Domain.Repositories
{
    public interface IErrorMessageConverterRepository
    {
        public string GetMessage(Language language, RiotSharpException exception);
        public string GetMessage(Language language, InternalException exception);
    }
}
