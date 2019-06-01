using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entities.People;

namespace Services.Vendor
{
    public interface IVendorService
    {
        IList<KeyValuePair<int, string>> GetAllVendorsKeyValuePairs();
        Provider GetProviderById(int id);
        DataRepository.Entities.Vendor GetVendorById(int id);
    }
}
