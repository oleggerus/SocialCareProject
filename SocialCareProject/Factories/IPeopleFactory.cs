using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository.Entities;
using DataRepository.Entities.People;
using SocialCareProject.Models;

namespace SocialCareProject.Factories
{
    public interface IPeopleFactory
    {
        User PrepareUser(RegistrationModel model);
        Customer PrepareCustomer(RegistrationModel model, User user, Address address);
        Provider PrepareProvider (RegistrationModel model, User user, Address address);
    }
}