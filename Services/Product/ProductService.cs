using DataRepository;
using DataRepository.RepositoryPattern;
using System.Linq;

namespace Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IRepository<DataRepository.Entities.Orders.Product> _productRepository;

        public ProductService(IRepository<DataRepository.Entities.Orders.Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public IPagedList<DataRepository.Entities.Orders.Product> GetAllProducts(int pageIndex = default(int), int pageSize = int.MaxValue)
        {
            var query = _productRepository.TableNoTracking.Where(x => x.IsActive && !x.IsDeleted);

            return new PagedList<DataRepository.Entities.Orders.Product>(query.OrderBy(x => x.CreatedOnUtc), pageIndex,
                pageSize);

        }

        public DataRepository.Entities.Orders.Product GetById(int id)
        {
            return _productRepository.GetById(id);
        }
    }
}
