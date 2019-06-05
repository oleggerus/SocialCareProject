using System.ComponentModel;

namespace DataRepository.Enums
{
    public enum CustomerCareStatuses
    {
        [Description("Просить догляду")]
        ПроситьДогляду = 1,

        [Description("Не потребує догляду")]
        НеПотребуєДогляду = 2,

        [Description("Під доглядом")]
        ПідДоглядом = 3
    }
}
