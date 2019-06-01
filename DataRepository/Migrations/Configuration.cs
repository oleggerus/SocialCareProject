using DataRepository.Entities;
using DataRepository.Entities.Orders;
using DataRepository.Entities.People;
using DataRepository.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Text;

namespace DataRepository.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<DataRepository.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.WorkerPersonAssignments.RemoveRange(context.WorkerPersonAssignments);
            context.ReturnRequests.RemoveRange(context.ReturnRequests);
            context.Offers.RemoveRange(context.Offers);
            context.Products.RemoveRange(context.Products);
            context.Categories.RemoveRange(context.Categories);
            context.Providers.RemoveRange(context.Providers);
            context.Workers.RemoveRange(context.Workers);
            context.Vendors.RemoveRange(context.Vendors);
            context.Customers.RemoveRange(context.Customers);
            context.Administrations.RemoveRange(context.Administrations);
            context.Addresses.RemoveRange(context.Addresses);
            context.Users.RemoveRange(context.Users);
            context.Roles.RemoveRange(context.Roles);
            context.CareRequests.RemoveRange(context.CareRequests);


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
            var workerRole = new Role
            {
                Name = "WorkerRole",
                AreaId = (int)AreaTypes.Worker,
                Permissions = new List<Permission>()

            };
            context.Roles.AddOrUpdate(customerRole);
            context.Roles.AddOrUpdate(vendorRole);
            context.Roles.AddOrUpdate(administrationLeadRole);
            context.Roles.AddOrUpdate(administrationRole);
            context.Roles.AddOrUpdate(adminRole);
            context.Roles.AddOrUpdate(workerRole);

            #endregion


            //"password"  - "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo"

            #region users

            var custUser1 = new User
            {
                Role = customerRole,
                FirstName = "Петро",
                LastName = "Іванов",
                DateOfBirth = new DateTime(1982, 02, 02),
                Email = "customer@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "connor"
            };
            var custUser2 = new User
            {
                Role = customerRole,
                FirstName = "Марія",
                LastName = "Петрова",
                DateOfBirth = new DateTime(1932, 01, 02),
                Email = "customer1@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Жінка,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "0633126355",
                Username = "username1"
            };
            var administrationUser = new User
            {
                Role = administrationRole,
                FirstName = "Андрій",
                LastName = "Шишкарук",
                DateOfBirth = new DateTime(1943, 11, 11),
                Email = "administration@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "administration"
            };
            var administrationUserContact = new User
            {
                Role = administrationRole,
                FirstName = "Олег",
                LastName = "Павлов",
                DateOfBirth = new DateTime(1943, 11, 11),
                Email = "workercontact@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "1212112120",
                Username = "administration"
            };

            var administrationLeadUser = new User
            {
                Role = administrationLeadRole,
                FirstName = "Роман",
                LastName = "Данилюк",
                DateOfBirth = new DateTime(1952, 12, 02),
                Email = "administrationLead@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "administrationLead"
            };

            var workerUser = new User
            {
                Role = workerRole,
                FirstName = "Олександр",
                LastName = "Лисенко",
                DateOfBirth = new DateTime(1952, 12, 02),
                Email = "worker@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "administrationLead"
            };

            var vendorUser = new User
            {
                Role = vendorRole,
                FirstName = "Провайдер",
                LastName = "Контакт",
                MiddleName = "Анатолійович",
                DateOfBirth = new DateTime(1935, 07, 14),
                Email = "vendor@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "vendor"
            };
            var providerUser = new User
            {
                Role = vendorRole,
                FirstName = "Жорже",
                LastName = "Мендес",
                MiddleName = "Анатолійович",
                DateOfBirth = new DateTime(1935, 07, 14),
                Email = "vendor@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "provider"
            };
            var providerNotVendorUser = new User
            {
                Role = vendorRole,
                FirstName = "Міно",
                LastName = "Райола",
                MiddleName = "Анатолійович",
                DateOfBirth = new DateTime(1935, 07, 14),
                Email = "vendor2@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "provider2"
            };

            var adminUser = new User
            {
                Role = adminRole,
                FirstName = "Адмін",
                LastName = "Адмін",
                DateOfBirth = new DateTime(1982, 02, 02),
                Email = "admin@mail.com",
                IsActive = true,
                IsDeleted = false,
                Gender = (int)GenderEnum.Чоловік,
                Password = "21YbvcPQOs8JTfRkU3D/TsAzFWuqKPYo",
                PasswordSalt = "jr0YbgcGuSLt5TWTti6vdw==",
                Phone = "09090909990",
                Username = "admin"
            };

            context.Users.AddOrUpdate(custUser1);
            context.Users.AddOrUpdate(custUser2);
            context.Users.AddOrUpdate(administrationUser);
            context.Users.AddOrUpdate(administrationLeadUser);
            context.Users.AddOrUpdate(administrationUserContact);
            context.Users.AddOrUpdate(vendorUser);
            context.Users.AddOrUpdate(adminUser);
            context.Users.AddOrUpdate(providerUser);
            context.Users.AddOrUpdate(providerNotVendorUser);



            #endregion

            #region Address

            var personAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "5, 12",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Лукаша"
            };
            var personAddress2 = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "5, 12",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Лукаша"
            };
            var administrationUserAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "1",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7500",
                Street = "Київська"
            };
            var administrationLeadAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "буд. 2, кв. 13",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Бандери"
            };
            var administrationAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "БУД. 21",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Проспект Шевченка"
            };
            var vendorAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "12",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Лукаша"
            };
            var providerAddress = new Address
            {
                City = "Львів",
                Deleted = false,
                HouseNameRoomNumber = "122",
                RegionId = (int)Regions.Львівська,
                ZipPostalCode = "7508",
                Street = "Науккова"
            };

            var adminAddress = new Address
            {
                City = "Ужгород",
                Deleted = false,
                HouseNameRoomNumber = "12",
                RegionId = (int)Regions.Закарпатська,
                ZipPostalCode = "0101",
                Street = "Шевченка"
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
                Contact = administrationUserContact,
                Description = "Міська адміністрація Львівського району",
                Name = "Львівська адміністрація",
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
                Description = "Мережа продажу товарів для дому",
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
                StatusId = (int)CustomerCareStatuses.ПідДоглядом
            };
            var customer2 = new Customer
            {
                Address = personAddress2,
                Administration = administration,
                User = custUser2,
                IsInvalid = true,
                IsSelfPaid = false,
                StatusId = (int)CustomerCareStatuses.НеПотребуєДогляду
            };

            context.Customers.AddOrUpdate(customer);
            context.Customers.AddOrUpdate(customer2);

            var worker = new Worker
            {
                User = administrationUser,
                Administration = administration,
                IsLead = false,
                PositionId = (int)WorkerPositions.Джуніор,
            };
            var lead = new Worker
            {
                User = administrationLeadUser,
                Administration = administration,
                IsLead = true,
                PositionId = (int)WorkerPositions.Джуніор,
            };

            var socWorker = new Worker
            {
                User = workerUser,
                Administration = administration,
                IsLead = false
            };
            context.Workers.AddOrUpdate(worker);
            context.Workers.AddOrUpdate(lead);
            context.Workers.AddOrUpdate(socWorker);

            var provider = new Provider
            {
                Address = providerAddress,
                User = providerUser,
                PositionId = (int)ProviderPositions.Мідл,
                Vendor = vendor
            };

            var providerWithoutVendor = new Provider
            {
                Address = providerAddress,
                User = providerUser,
            };

            context.Providers.AddOrUpdate(provider);
            context.Providers.AddOrUpdate(providerWithoutVendor);

            #endregion

            #region Category

            var healthCareCategory = new Category
            {
                Name = "Охорона здоров'я"
            };
            var homeHelCategory = new Category
            {
                Name = "Допомога по дому"
            };
            var psychoHelpCategory = new Category
            {
                Name = "Консультація"
            };

            context.Categories.Add(healthCareCategory);
            context.Categories.Add(homeHelCategory);
            context.Categories.Add(psychoHelpCategory);

            #endregion

            #region Products

            var wheelChair = new Product
            {
                Category = healthCareCategory,
                Name = "Інвалідний візок",
                Description = "Дуже зручний і сучасний візок",
                Manufacturer = "Tesla",
                Height = 1,
                Width = 1,
                Weight = 4,
                IsActive = true,
                IsDeleted = false,
                Price = 1250,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = true,
                CreatedBy = provider,
                Length = 1,
            };

            var bones = new Product
            {
                Category = healthCareCategory,
                Name = "Костилі",
                Description = "2 шт.",
                Manufacturer = "Tesla",
                Height = 1,
                IsActive = true,
                IsDeleted = false,
                Price = 50,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = false,
                CreatedBy = providerWithoutVendor,
            };
            var wheelChair1 = new Product
            {
                Category = healthCareCategory,
                Name = "Інвалідний візок ",
                Description = "Дуже зручний і сучасний візок",
                Manufacturer = "Tesla 1",
                Height = 1,
                Width = 1,
                Weight = 4,
                IsActive = true,
                IsDeleted = false,
                Price = 1250,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = true,
                CreatedBy = provider,
                Length = 1,
            };

            var bones1 = new Product
            {
                Category = healthCareCategory,
                Name = "Костилі 1",
                Description = "2 шт.",
                Manufacturer = "Tesla 1",
                Height = 1,
                IsActive = true,
                IsDeleted = false,
                Price = 50,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = false,
                CreatedBy = providerWithoutVendor,
            };

            var wheelChair2 = new Product
            {
                Category = healthCareCategory,
                Name = "Інвалідний візок 2",
                Description = "Дуже зручний і сучасний візок",
                Manufacturer = "Tesla 2",
                Height = 1,
                Width = 1,
                Weight = 4,
                IsActive = true,
                IsDeleted = false,
                Price = 1250,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = true,
                CreatedBy = provider,
                Length = 1,
            };

            var bones2 = new Product
            {
                Category = healthCareCategory,
                Name = "Костилі 2",
                Description = "2 шт.",
                Manufacturer = "Tesla 2 ",
                Height = 1,
                IsActive = true,
                IsDeleted = false,
                Price = 50,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = false,
                CreatedBy = providerWithoutVendor,
            };

            var wheelChair3 = new Product
            {
                Category = healthCareCategory,
                Name = "Інвалідний візок 3",
                Description = "Дуже зручний і сучасний візок",
                Manufacturer = "Tesla 3",
                Height = 1,
                Width = 1,
                Weight = 4,
                IsActive = true,
                IsDeleted = false,
                Price = 1250,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = true,
                CreatedBy = provider,
                Length = 1,
            };

            var bones3 = new Product
            {
                Category = healthCareCategory,
                Name = "Костилі 3",
                Description = "2 шт.",
                Manufacturer = "Tesla 3",
                Height = 1,
                IsActive = true,
                IsDeleted = false,
                Price = 50,
                StatusId = (int)ProductStatuses.Продукт,
                IsGift = false,
                IsNew = false,
                CreatedBy = providerWithoutVendor,
            };


            context.Products.AddOrUpdate(bones);
            context.Products.AddOrUpdate(wheelChair);
            context.Products.AddOrUpdate(bones1);
            context.Products.AddOrUpdate(wheelChair1);
            context.Products.AddOrUpdate(bones2);
            context.Products.AddOrUpdate(wheelChair2);
            context.Products.AddOrUpdate(bones3);
            context.Products.AddOrUpdate(wheelChair3);



            #endregion

            #region Offers

            var wheelChairOffer = new Offer
            {
                Product = wheelChair,
                CreatedBy = provider,
                Description = "Найкращий вибір",
                IsDeleted = false,
                StatusId = (int)OfferStatuses.PendingReview,
                Customer = customer
            };

            var bonesOffer = new Offer
            {
                Product = bones,
                CreatedBy = providerWithoutVendor,
                Description = "Думаю, це те що Вам потрібно",
                IsDeleted = false,
                ReviewedOnUtc = DateTime.UtcNow,
                StatusId = (int)OfferStatuses.Declined,
                ReviewedBy = administrationLeadUser,
                Customer = customer
            };

            context.Offers.AddOrUpdate(wheelChairOffer);
            context.Offers.AddOrUpdate(bonesOffer);
            #endregion

            #region ReturnRequest

            var bonesReturn = new ReturnRequest
            {
                CreatedBy = bonesOffer.ReviewedBy,
                Offer = bonesOffer,
                Reason = "Товар у дуже поганому стані"
            };

            context.ReturnRequests.AddOrUpdate(bonesReturn);

            #endregion

            #region PersonRequest

            var personRequest1 = new PersonRequest
            {
                IsDeleted = false,
                Category = healthCareCategory,
                StatusId = (int)PersonRequestStatuses.Opened,
                Name = "Шукаю масажиста",
                Description = "я хотів би знайти масажиста",
                Customer = customer,
                CreatedBy = customer,
            };

            context.PersonRequests.AddOrUpdate(personRequest1);
            #endregion

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
                Console.WriteLine(ex.Message);

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
