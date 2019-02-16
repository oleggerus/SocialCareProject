using System;

namespace SocialCareProject.Areas.Customer.Models.Product
{
    public class ProductItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
    }
}