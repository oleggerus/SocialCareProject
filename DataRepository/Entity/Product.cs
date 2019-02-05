using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Product : BaseEntity
    {
        public Product()
        {
            this.Price = 0.0;
            this.PriceFrom = 0.0;
            this.PriceTo = 0.0;
            this.Height = 0.0;
            this.Length = 0.0;
            this.Weight = 0.0;
            this.Width = 0.0;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsGift { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Manufacturer { get; set; }
        public double Price{ get; set; }
        public double PriceFrom { get; set; }
        public double PriceTo { get; set; }
        public double Weight { get; set; }
        public double Length{ get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int? ScheduleId { get; set; }
        public int StatusId { get; set; }


        public DateTime CreatedOnUtc { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual ProductSchedule Schedule { get; set; }
        public virtual Category Category{ get; set; }

    }
}
