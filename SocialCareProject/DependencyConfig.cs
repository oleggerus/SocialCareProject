using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DataRepository.RepositoryPattern;
using Services;
using Services.Address;
using Services.Administration;
using Services.Assignments;
using Services.Offer;
using Services.People;
using Services.Product;
using Services.Vendor;

namespace SocialCareProject
{
    public class DependencyConfig
    {
        public static void ConfigureContainer()
        {
            // получаем экземпляр контейнера
            var builder = new ContainerBuilder();

            // регистрируем контроллер в текущей сборке
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            //builder.RegisterType<EfRepository<User>>().As<IRepository<User>>().InstancePerLifetimeScope();

            // регистрируем споставление типов
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            builder.RegisterType<OfferService>().As<IOfferService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<AdministrationService>().As<IAdministrationService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerService>().As<ICustomerService>().InstancePerLifetimeScope();
            builder.RegisterType<ProviderService>().As<IProviderService>().InstancePerLifetimeScope();
            builder.RegisterType<WorkerService>().As<IWorkerService>().InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<VendorService>().As<IVendorService>().InstancePerLifetimeScope();
            builder.RegisterType<WorkerPersonAssignmentService>().As<IWorkerPersonAssignmentService>().InstancePerLifetimeScope();


            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
