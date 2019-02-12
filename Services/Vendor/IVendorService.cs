﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Vendor
{
    public interface IVendorService
    {
        IList<KeyValuePair<int, string>> GetAllVendorsKeyValuePairs();

    }
}
