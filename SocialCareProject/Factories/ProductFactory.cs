using System;
using System.Collections.Generic;
using System.Linq;
using DataRepository;
using DataRepository.Entities.Orders;
using SocialCareProject.Areas.Customer.Models.Product;
using SocialCareProject.Models;

namespace SocialCareProject.Factories
{
    public class ProductFactory : IProductFactory
    {
        public ProductItemModel PrepareProductItemModel(Product product)
        {
            return new ProductItemModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                CreatedOnUtc = product.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString),
                Manufacturer = product.Manufacturer,
                Price = product.Price,
                Picture = product.Picture
            };
        }

        public ProductModel PrepareProductModel(Product product)
        {
            throw new NotImplementedException();
        }

        public ProductListModel PrepareProductListModel(IPagedList<Product> products)
        {
            return new ProductListModel
            {
                Products = products.Select(PrepareProductItemModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(products)
            };
        }
    }
}