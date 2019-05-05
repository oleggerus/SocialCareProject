using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Enums
{
    public enum CareRequestStatuses
    {
        [Description("Потребує розгляду")]
        Opened = 1,

        [Description("Схвалений")]
        Approved= 2,

        [Description("Відхилений")]
        Rejected= 3
    }
}
