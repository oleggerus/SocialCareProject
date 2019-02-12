using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;

namespace Services.Vendor
{
    public class VendorService : IVendorService
    {
        private readonly IRepository<DataRepository.Entities.Vendor> _vendorRepository;

        public VendorService(IRepository<DataRepository.Entities.Vendor> vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }


        public IList<KeyValuePair<int, string>> GetAllVendorsKeyValuePairs()
        {
            return _vendorRepository.TableNoTracking.Select(x => new { x.Id, x.Name }).AsEnumerable()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        }
    }
}
