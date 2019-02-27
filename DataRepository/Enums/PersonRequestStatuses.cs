using System.ComponentModel;

namespace DataRepository.Enums
{
    public enum PersonRequestStatuses
    {
        [Description("Відкритий")]
        Opened = 1,
        [Description("Потребує розгляду")]
        PendingReview = 2,
        [Description("Закритий")]
        Closed = 3
    }
}
