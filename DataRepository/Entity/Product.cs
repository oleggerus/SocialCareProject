﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entity.People;

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

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool? IsNew { get; set; }
        public bool? IsGift { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
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

        [Required]
        public DateTime CreatedOnUtc { get; set; }
        [Required]
        public virtual User CreatedBy { get; set; }
        public virtual ProductSchedule Schedule { get; set; }
        [Required]
        public virtual Category Category{ get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<Offer> Offers { get; set; } = new List<Offer>();

    }
}
