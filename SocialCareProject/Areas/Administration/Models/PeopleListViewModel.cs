using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialCareProject.Areas.Customer.Models.Customer;
using SocialCareProject.Models;

namespace SocialCareProject.Areas.Administration.Models
{
    public class PeopleListViewModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<CustomerModel> People { get; set; } = new List<CustomerModel>();
    }
}