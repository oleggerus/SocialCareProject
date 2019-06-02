using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace SocialCareProject.Areas.Customer.Models.Administration
{
    public class AdministrationViewModel
    {
        public string Administration { get; set; }
        public string AdministrationPhone { get; set; }
        public string AdministrationContactName { get; set; }

        public string Description { get; set; }
        public string Email { get; set; }
        public string Address {get; set; }

    }

    public class AssignedPersonViewModel
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string Address { get; set; }
        public string Administration { get; set; }
    }
}