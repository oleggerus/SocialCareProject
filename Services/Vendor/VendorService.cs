using DataRepository.RepositoryPattern;
using System.Collections.Generic;
using System.Linq;
using DataRepository.Entities.People;

namespace Services.Vendor
{
    public class VendorService : IVendorService
    {

        private readonly IRepository<Provider> _providerRepository;
        private readonly IRepository<DataRepository.Entities.Vendor> _vendorRepository;


        public VendorService(IRepository<DataRepository.Entities.Vendor> vendorRepository,
            IRepository<Provider> providerRepository)
        {
            _vendorRepository = vendorRepository;
            _providerRepository = providerRepository;
        }


        public Provider GetProviderById(int id)
        {
            return _providerRepository.GetById(id);
        }

        public DataRepository.Entities.Vendor GetVendorById(int id)
        {
            return _vendorRepository.GetById(id);
        }

        public IList<KeyValuePair<int, string>> GetAllVendorsKeyValuePairs()
        {
            return _vendorRepository.TableNoTracking.Select(x => new { x.Id, x.Name }).AsEnumerable()
                .Select(x => new KeyValuePair<int, string>(x.Id, x.Name)).ToList();
        }
    }
}
