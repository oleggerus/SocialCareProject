using System.Collections.Generic;
using DataRepository.Entities.Orders;
using DataRepository.RepositoryPattern;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        public IList<DataRepository.Entities.Orders.Product> GetAllProducts()
        {
            throw new System.NotImplementedException();
        }
    }
}
