using System;
using System.Collections.Generic;
using DataRepository;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Customer.Models.Product
{
    public class ProductItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
        public byte[] Picture { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
    }


    public class ProductListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<ProductItemModel> Products { get; set; } = new List<ProductItemModel>();
    }
}