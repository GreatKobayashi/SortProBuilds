using DefeatYourOpponent.Domain.Entities;
using System.Text.Json.Serialization;

namespace DefeatYourOpponent.Domain
{
    public static class Shared
    {
#pragma warning disable CS8618
        [JsonInclude]
        public static SettingEntity SettingEntity { get; set; }
#pragma warning restore CS8618
        public static string ModalDialogId { get; } = "modalDialog";
    }
}
