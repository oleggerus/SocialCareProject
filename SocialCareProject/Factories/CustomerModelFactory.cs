using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataRepository.Entities.People;
using SocialCareProject.Areas.Customer.Models.Customer;

namespace SocialCareProject.Factories
{
    public class CustomerModelFactory:ICustomerModelFactory
    {
        public CustomerModel PrepareCustomerModel(Customer customer)
        {
            var model = new CustomerModel
            {
                Id = customer.UserId,
                Administration = customer.Administration.Name,
                StatusId = customer.StatusId,
                Email = customer.User.Email,
                Phone = customer.User.Phone,
                DateOfBirth = customer.User.DateOfBirth,
                MiddleName = customer.User.MiddleName,
                City = customer.Address.City,
                FirstName = customer.User.FirstName,
                Street = customer.Address.Street,
                LastName = customer.User.LastName,
                IsSelfPaid = customer.IsSelfPaid,
                RegionId = customer.Address.RegionId,
                ZipPostalCode = customer.Address.ZipPostalCode,
                HouseNameRoomNumber = customer.Address.HouseNameRoomNumber,
                IsInvalid = customer.IsInvalid,
                Avatar = customer.User.Avatar,
                Gender = customer.User.Gender,
                HomePhoneNumber = customer.Address.PhoneNumber,
                Info = customer.Info
            };

            return model;
        }
    }
}