using DataRepository;
using DataRepository.Entities;
using DataRepository.Entities.People;
using Services;
using SocialCareProject.Models;
using System;

namespace SocialCareProject.Factories
{
    public class PeopleModelFactory : IPeopleFactory
    {
        private readonly IRoleService _roleService;
        private readonly IAuthenticationService _authenticationService;
        public PeopleModelFactory(IAuthenticationService authenticationService,
            IRoleService roleService)
        {
            _authenticationService = authenticationService;
            _roleService = roleService;
        }

        public User PrepareUser(RegistrationModel model)
        {
            var salt = _authenticationService.CreateSaltKey(Constants.UserSettings.SaltKeyNumberOfSymbols);
            var role = _roleService.GetRoleByAreaId(model.RoleId);
            return new User
            {
                CreatedOnUtc = DateTime.UtcNow,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = (int)model.Gender,
                IsActive = true,
                IsDeleted = false,
                MiddleName = model.MiddleName,
                PasswordSalt = salt,
                Password = _authenticationService.EncryptText(model.Password, salt),
                Phone = model.Phone,
                Role = role,
                RoleId = role.Id
            };
        }

        public Customer PrepareCustomer(RegistrationModel model, User user, Address address)
        {
            return new Customer
            {
                User = user,
                AdministrationId = model.AdministrationId.Value,
                CreatedOnUtc = DateTime.UtcNow,
                Address = address,

            };
        }

        public Provider PrepareProvider(RegistrationModel model, User user, Address address)
        {
            var provider = new Provider
            {
                User = user,
                CreatedOnUtc = DateTime.UtcNow,
                Address = address
            };
            if (model.VendorId.HasValue)
            {
                provider.VendorId = model.VendorId.Value;
            }

            return provider;
        }
    }
}