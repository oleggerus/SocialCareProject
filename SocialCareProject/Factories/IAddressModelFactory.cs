using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository.Entities;
using SocialCareProject.Models;

namespace SocialCareProject.Factories
{
    public interface IAddressModelFactory
    {
        Address PrepareAddressFromRegistrationModel(RegistrationModel model);
    }
}