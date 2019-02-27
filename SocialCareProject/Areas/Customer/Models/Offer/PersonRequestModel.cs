using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialCareProject.Areas.Customer.Models.Offer
{
    public class PersonRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string Category { get; set; }
        public int StatusId { get; set; }
    }
}