using DefeatYourOpponent.Domain.Entities;
using System.Text.Json.Serialization;

namespace RiotApiController.Domain.Entities
{
    public class SettingEntity
    {
        [JsonInclude]
        public RiotControllerSettingEntity RiotControllerSetting { get; private set; }

        public SettingEntity(RiotControllerSettingEntity riotControllerSetting)
        {
            RiotControllerSetting = riotControllerSetting;
        }
    }
}
