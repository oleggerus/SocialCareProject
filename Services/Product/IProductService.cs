using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository;

namespace Services.Product
{
    public interface IProductService
    {
        IPagedList<DataRepository.Entities.Orders.Product> GetAllProducts(int pageIndex = default(int), int pageSize = int.MaxValue);

        DataRepository.Entities.Orders.Product GetById(int id);

    }
}
