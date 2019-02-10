using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Product
{
    public interface IProductService
    {
        IList<DataRepository.Entities.Orders.Product> GetAllProducts();

    }
}
