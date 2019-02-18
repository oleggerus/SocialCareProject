using System.ComponentModel;

namespace DataRepository.Enums
{
    public enum CustomerCareStatuses
    {
        [Description("Потребує догляду")]
        ПотребуєДогляду = 1,

        [Description("Не потребує догляду")]
        НеПотребуєДогляду = 2,

        [Description("Під доглядом")]
        ПідДоглядом = 3
    }
}
