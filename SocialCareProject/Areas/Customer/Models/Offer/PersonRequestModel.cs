using SocialCareProject.Models;
using System.Collections.Generic;

namespace SocialCareProject.Areas.Customer.Models.Offer
{
    public class PersonRequestItemModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedOnUtc { get; set; }
        public string ClosedOnUtc { get; set; }
        public int Id { get; set; }

        public string Category { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }

    }

    public class PersonRequestListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<PersonRequestItemModel> Items { get; set; } = new List<PersonRequestItemModel>();
    }
}