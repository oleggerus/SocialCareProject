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
using System.Web;
using System.Web.Mvc;
using SocialCareProject.Factories;

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

            builder.Register(c =>
                        (new HttpContextWrapper(HttpContext.Current) as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();


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
            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerLifetimeScope();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerLifetimeScope();
            builder.RegisterType<PersonRequestService>().As<IPersonRequestService>().InstancePerLifetimeScope();


            builder.RegisterType<PeopleModelFactory>().As<IPeopleFactory>().InstancePerLifetimeScope();
            builder.RegisterType<AddressModelFactory>().As<IAddressModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<ProductFactory>().As<IProductFactory>().InstancePerLifetimeScope();
            builder.RegisterType<OfferModelFactory>().As<IOfferModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<CustomerModelFactory>().As<ICustomerModelFactory>().InstancePerLifetimeScope();
            builder.RegisterType<PersonRequestModelFactory>().As<IPersonRequestModelFactory>().InstancePerLifetimeScope();

            
            // создаем новый контейнер с теми зависимостями, которые определены выше
            var container = builder.Build();

            // установка сопоставителя зависимостей
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
