using DefeatYourOpponent.Domain.Exceptions;
using DefeatYourOpponent.Domain.Logics;
using DefeatYourOpponent.Domain.Misc;
using DefeatYourOpponent.Domain.Repositories;
using RiotApiController.Domain.Helper;
using RiotApiWrapper.Exceptions;

namespace DefeatYourOpponent.Infrastructure.Json
{
    public class ErrorMessageConverterJson : IErrorMessageConverterRepository
    {
        private Dictionary<string, Dictionary<string, string>> _riotApiErrorMessageList;
        private Dictionary<string, Dictionary<string, string>> _internalErrorMessageList;

        public ErrorMessageConverterJson(string riotApiErrorMessagelistFilePath, string internalErrorMessageListFilePath)
        {
            _riotApiErrorMessageList = JsonSerializerHelper
                .Deserialize<Dictionary<string, Dictionary<string, string>>>(riotApiErrorMessagelistFilePath, FileAccess.Read);
            _internalErrorMessageList = JsonSerializerHelper
                .Deserialize<Dictionary<string, Dictionary<string, string>>>(internalErrorMessageListFilePath, FileAccess.Read);
        }

        public string GetMessage(Language language, RiotApiException exception)
        {
            return _riotApiErrorMessageList.GetInternalValue(exception.Message, language.ToString());
        }

        public string GetMessage(Language language, InternalException exception)
        {
            return _internalErrorMessageList.GetInternalValue(exception.ErrorCode, language.ToString());
        }
    }
}
