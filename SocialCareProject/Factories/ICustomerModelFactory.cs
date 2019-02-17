using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using DataRepository.Entities.People;
using SocialCareProject.Areas.Customer.Models.Customer;

namespace SocialCareProject.Factories
{
    public interface ICustomerModelFactory
    {
        CustomerModel PrepareCustomerModel(Customer customer);
    }
}