using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Entity.People
{
    public class Provider: BaseEntity
    {
        public  Provider()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        [Required]
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        public int? PositionId { get; set; }
        public virtual Address Address { get; set; }
        [Required]
        public virtual User User { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
