using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository;
using DataRepository.Entities.Orders;
using SocialCareProject.Areas.Customer.Models.Product;

namespace SocialCareProject.Factories
{
    public interface IProductFactory
    {
        
        ProductItemModel PrepareProductItemModel(Product product);

        ProductDetailsModel PrepareProductDetailsModel(Product product);

        ProductListModel PrepareProductListModel(IPagedList<Product> products);
    }
}