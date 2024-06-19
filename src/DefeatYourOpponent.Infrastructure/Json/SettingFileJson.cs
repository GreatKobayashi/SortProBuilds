using DefeatYourOpponent.Domain.Entities;
using RiotApiController.Domain.Helper;

namespace DefeatYourOpponent.Infrastructure.Json
{
    public class SettingFileJson : ISettingFileRepository
    {
        private string _settingFileName = "DefeatYourOpponent.json";

        public SettingEntity GetEntity()
        {
            try
            {
                return JsonSerializerHelper.Deserialize<SettingEntity>(_settingFileName, FileAccess.Read);
            }
            catch (Exception ex)
            {
                throw new Exception("設定ファイル読み込み失敗", ex);
            }
        }
    }
}
