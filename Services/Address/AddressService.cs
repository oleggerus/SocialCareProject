using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.RepositoryPattern;

namespace Services.Address
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<DataRepository.Entities.Address> _addressRepository;
        public AddressService(
            IRepository<DataRepository.Entities.Address> addressRepository)
        {
            _addressRepository = addressRepository;
            
        }


        public DataRepository.Entities.Address GetAddressById(int id)
        {
            return _addressRepository.GetById(id);
        }
        public DataRepository.Entities.Address UpdateAddress(DataRepository.Entities.Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }
            _addressRepository.Update(address);

            return address;
        }
    }
}
