using System.ComponentModel;

namespace DataRepository.Enums
{
    public enum OfferStatuses
    {
        [Description("Потребує розгляду")]
        PendingReview = 1,

        [Description("Підтвердежено")]
        Approved = 2,

        [Description("Відхилено")]
        Declined = 3,

        [Description("Не актуально")]
        NotActual = 4
    }
}
