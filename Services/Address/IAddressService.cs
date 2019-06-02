using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Address
{
    public interface IAddressService
    {
        DataRepository.Entities.Address GetAddressById(int id);

        DataRepository.Entities.Address UpdateAddress(DataRepository.Entities.Address address);

    }
}
