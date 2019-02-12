using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Enums
{
    public enum AreaTypes
    {
        [Description("Людина")]
        Customer = 1,
        [Description("Працівник адміністрації")]
        Administration = 2,
        [Description("Постачальник послуг")]
        Vendor = 3,
        [Description("Адмін")]
        Admin = 4
    }
}
