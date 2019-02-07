using DataRepository.Entity;
using DataRepository.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using DataRepository.Entity.People;

namespace DataRepository.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataRepository.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataRepository.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Providers.RemoveRange(context.Providers);
            context.Workers.RemoveRange(context.Workers);
            context.Vendors.RemoveRange(context.Vendors);
            context.Customers.RemoveRange(context.Customers);
            context.Administrations.RemoveRange(context.Administrations);
            context.Addresses.RemoveRange(context.Addresses);
            context.Users.RemoveRange(context.Users);
            context.Roles.RemoveRange(context.Roles);



            #region roles

            var customerRole = new Role
            {
                Name = "CustomerRole",
                AreaId = (int)AreaTypes.Customer,
                Permissions = new List<Permission>()

            };
            var administrationRole = new Role
            {
                Name = "AdministrationRole",
                AreaId = (int)AreaTypes.Administration,
                Permissions = new List<Permission>()

            };
            var administrationLeadRole = new Role
            {
                Name = "AdministrationLeadRole",
                AreaId = (int)AreaTypes.Administration,
                Permissions = new List<Permission>()

            };
            var vendorRole = new Role
            {
                Name = "VendorRole",
                AreaId = (int)AreaTypes.Vendor,
                Permissions = new List<Permission>()

            };
            var adminRole = new Role
            {
                Name = "AdminRole",
                AreaId = (int)AreaTypes.Administration,
                Permissions = new List<Permission>()

            };

            context.Roles.AddOrUpdate(customerRole);
            context.Roles.AddOrUpdate(vendorRole);
            context.Roles.AddOrUpdate(administrationLeadRole);
            context.Roles.AddOrUpdate(administrationRole);
            context.Roles.AddOrUpdate(adminRole);

            #endregion

            #region users

            var custUser1 = new User
            {
                Role = customerRole,
                FirstName = "����",
                LastName = "������",
                DateOfBirth = new DateTime(1982, 02, 02),
                Email = "customer@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "connor"
            };
            var custUser2 = new User
            {
                Role = customerRole,
                FirstName = "³�",
                LastName = "ĳ����",
                DateOfBirth = new DateTime(1932, 01, 02),
                Email = "customer1@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "username1"
            };
            var administrationUser = new User
            {
                Role = administrationRole,
                FirstName = "���",
                LastName = "����",
                DateOfBirth = new DateTime(1943, 11, 11),
                Email = "administration@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "administration"
            };
            var administrationLeadUser = new User
            {
                Role = administrationLeadRole,
                FirstName = "���",
                LastName = "��������",
                DateOfBirth = new DateTime(1952, 12, 02),
                Email = "administrationLead@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "administrationLead"
            };
            var vendorUser = new User
            {
                Role = vendorRole,
                FirstName = "���������",
                LastName = "�������",
                MiddleName = "�����������",
                DateOfBirth = new DateTime(1935, 07, 14),
                Email = "vendor@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "vendor"
            };
            var providerUser = new User
            {
                Role = vendorRole,
                FirstName = "�����",
                LastName = "������",
                MiddleName = "�����������",
                DateOfBirth = new DateTime(1935, 07, 14),
                Email = "vendor@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "provider"
            };
            var adminUser = new User
            {
                Role = adminRole,
                FirstName = "����",
                LastName = "����",
                DateOfBirth = new DateTime(1982, 02, 02),
                Email = "admin@mail.com",
                IsActive = true,
                IsDeleted = false,
                IsMale = true,
                Password = "123",
                Phone = "09090909990",
                Username = "admin"
            };

            context.Users.AddOrUpdate(custUser1);
            context.Users.AddOrUpdate(custUser2);
            context.Users.AddOrUpdate(administrationUser);
            context.Users.AddOrUpdate(administrationLeadUser);
            context.Users.AddOrUpdate(vendorUser);
            context.Users.AddOrUpdate(adminUser);
            context.Users.AddOrUpdate(providerUser);



            #endregion

            #region Address

            var personAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "5, 12",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "������"
            };
            var personAddress2 = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "5, 12",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "������"
            };
            var administrationUserAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "1",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7500",
                Street = "�������"
            };
            var administrationLeadAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "���. 2, ��. 13",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "�������"
            };
            var administrationAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "���. 21",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "�������� ��������"
            };
            var vendorAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "12",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "������"
            };
            var providerAddress = new Address
            {
                City = "����",
                Deleted = false,
                HouseNameRoomNumber = "122",
                RegionId = (int)Regions.��������,
                ZipPostalCode = "7508",
                Street = "��������"
            };

            var adminAddress = new Address
            {
                City = "�������",
                Deleted = false,
                HouseNameRoomNumber = "12",
                RegionId = (int)Regions.������������,
                ZipPostalCode = "0101",
                Street = "��������"
            };

            context.Addresses.AddOrUpdate(personAddress);
            context.Addresses.AddOrUpdate(personAddress2);
            context.Addresses.AddOrUpdate(vendorAddress);
            context.Addresses.AddOrUpdate(adminAddress);
            context.Addresses.AddOrUpdate(administrationLeadAddress);
            context.Addresses.AddOrUpdate(administrationUserAddress);
            context.Addresses.AddOrUpdate(providerAddress);


            #endregion

            #region Administrtion

            var administration = new Administration
            {
                Address = administrationAddress,
                CreatedBy = adminUser,
                Description = "̳���� ����������� ���������� ������",
                Name = "�������� �����������",
                Email = "lviv@mail.com",
                Phone = "0101010",
                Url = "lviv.com.ua",
            };

            context.Administrations.Add(administration);

            #endregion

            #region Vendor

            var vendor = new Vendor()
            {
                Address = vendorAddress,
                CreatedBy = adminUser,
                Description = "������ ������� ������ ��� ����",
                Email = "homecarer@mail.com",
                Name = "Home Carer",
                IsActive = true,
                IsDeleted = false,
                Phone = "10010123",
                Url = "homecarer.com.ua"
            };

            context.Vendors.AddOrUpdate(vendor);
            #endregion

            #region persons

            var customer = new Customer
            {
                Address = personAddress,
                Administration = administration,
                User = custUser1,
                IsInvalid = false,
                IsSelfPaid = false,
            };
            var customer2 = new Customer
            {
                Address = personAddress2,
                Administration = administration,
                User = custUser2,
                IsInvalid = true,
                IsSelfPaid = false,
            };

            context.Customers.AddOrUpdate(customer);
            context.Customers.AddOrUpdate(customer2);

            var worker = new Worker
            {
                User = administrationUser,
                Administration = administration,
                IsLead = false,
                PositionId = (int)WorkerPositions.������,
            };
            var lead = new Worker
            {
                User = administrationLeadUser,
                Administration = administration,
                IsLead = true,
                PositionId = (int)WorkerPositions.������,
            };
            context.Workers.AddOrUpdate(worker);
            context.Workers.AddOrUpdate(lead);

            var provider = new Provider
            {
                Address = providerAddress,
                User = providerUser,
                PositionId = (int) ProviderPositions.̳��,
                Vendor = vendor
            };

            context.Providers.AddOrUpdate(provider);

            #endregion

            SaveChanges(context);
            base.Seed(context);

        }
        private static void SaveChanges(DbContext context)
        {
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();
                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }
                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }

}
