using System;
using DataRepository.Entities;
using SocialCareProject.Models;

namespace SocialCareProject.Factories
{
    public class AddressModelFactory : IAddressModelFactory
    {
        public Address PrepareAddressFromRegistrationModel(RegistrationModel model)
        {
            return new Address
            {
                CreatedOnUtc = DateTime.UtcNow,
                City = model.City,
                Deleted = false,
                Email = model.Email,
                HouseNameRoomNumber = model.HouseNameRoomNumber,
                PhoneNumber = model.Phone,
                Street = model.Street,
                RegionId = (int)model.RegionId,
                ZipPostalCode = model.ZipPostalCode
            };
        }
    }
}