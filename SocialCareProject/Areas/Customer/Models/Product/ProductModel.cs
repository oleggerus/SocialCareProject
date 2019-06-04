using SocialCareProject.Models;
using System;
using System.Collections.Generic;

namespace SocialCareProject.Areas.Customer.Models.Product
{
    public class ProductItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
        public byte[] Picture { get; set; }
    }

    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }
        public string CreatedOnUtc { get; set; }
        public string Manufacturer { get; set; }
    }

    public class ProductDetailsModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsGift { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int? ScheduleId { get; set; }
        public bool IsService { get; set; }
        public byte[] Picture { get; set; }
        public int CategoryId { get; set; }
        public int CreatedById { get; set; }
        public string Provider { get; set; }
        public string Vendor { get; set; }
        public string Category { get; set; }
        public bool IsRecurring { get; set; }
        public bool BasedOnWeek { get; set; }
        public int? NumberOfCycles { get; set; }
        public int NumberOfWeeksForRepeating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool AvailableOnMonday { get; set; }
        public bool AvailableOnTuesday { get; set; }
        public bool AvailableOnWednesday { get; set; }
        public bool AvailableOnThursday { get; set; }
        public bool AvailableOnFriday { get; set; }
        public bool AvailableOnSaturday { get; set; }
        public bool AvailableOnSunday { get; set; }
    }


    public class ProductListModel
    {
        public SimplePagerModel Pager { get; set; }
        public IList<ProductItemModel> Products { get; set; } = new List<ProductItemModel>();
    }
}