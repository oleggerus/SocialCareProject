using DataRepository;
using DataRepository.Entities.Orders;
using DataRepository.Extensions;
using SocialCareProject.Areas.Customer.Models.Product;
using System.Linq;
using Services.People;
using Services.Vendor;

namespace SocialCareProject.Factories
{
    public class ProductFactory : IProductFactory
    {
        private readonly IVendorService _vendorService;
        public ProductFactory(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        public ProductItemModel PrepareProductItemModel(Product product)
        {
            return new ProductItemModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                CreatedOnUtc = product.CreatedOnUtc.ToString(Constants.DateFormat.ShortDateString),
                Manufacturer = product.Manufacturer,
                Price = product.Price,
                Picture = product.Picture
            };
        }

        public ProductDetailsModel PrepareProductDetailsModel(Product product)
        {
            var providerCreator = _vendorService.GetProviderById(product.CreatedById);
            
            var model = new ProductDetailsModel
            {

                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                IsService = product.ScheduleId.HasValue,            
                Category = product.Category.Name,
            };
            if (providerCreator != null)
            {
                model.Provider = providerCreator.User.GetFullName();
            }
            if (providerCreator != null && providerCreator.VendorId.HasValue)
            {
                var vendor = _vendorService.GetVendorById(providerCreator.VendorId.Value);
                model.Vendor = vendor.Name;
            }

            if (product.ScheduleId.HasValue)
            {
                model.AvailableOnMonday = product.Schedule.AvailableOnMonday;
                model.AvailableOnTuesday = product.Schedule.AvailableOnTuesday;
                model.AvailableOnWednesday = product.Schedule.AvailableOnWednesday;
                model.AvailableOnThursday = product.Schedule.AvailableOnThursday;
                model.AvailableOnFriday = product.Schedule.AvailableOnFriday;
                model.AvailableOnSaturday= product.Schedule.AvailableOnSaturday;
                model.AvailableOnSunday = product.Schedule.AvailableOnSunday;
                model.ScheduleId = product.ScheduleId;
                model.BasedOnWeek = product.Schedule.BasedOnWeek;
                //and so on
            }
            else
            {
                model.IsNew = product.IsNew;
                model.IsGift = product.IsGift;
                model.Height = product.Height;
                model.Manufacturer = product.Manufacturer;
                model.Length = product.Length;
                model.Picture = product.Picture;
                model.Width = product.Width;
                model.Weight = product.Weight;
            }

            return model;
        }

        public ProductListModel PrepareProductListModel(IPagedList<Product> products)
        {
            return new ProductListModel
            {
                Products = products.Select(PrepareProductItemModel).ToList(),
                Pager = Extensions.Extensions.ToSimplePagerModel(products)
            };
        }
    }
}