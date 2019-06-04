using SocialCareProject.Models;
using System.Collections.Generic;

namespace SocialCareProject.Areas.Customer.Models.Offer
{

    public class OfferItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string ModifiedOnUtc { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
    }

    public class OfferModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
    }


    public class OfferListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<OfferItemModel> Offers { get; set; } = new List<OfferItemModel>();
    }
}