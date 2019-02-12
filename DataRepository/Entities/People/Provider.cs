using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Entities.People
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

        public int UserId { get; set; }

        public int? VendorId { get; set; }

        public virtual Address Address { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        [ForeignKey("VendorId")]
        public virtual Vendor Vendor { get; set; }
    }
}
