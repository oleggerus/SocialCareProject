using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataRepository.Entities.People;

namespace DataRepository.Entities.Orders
{
    public class ReturnRequest : BaseEntity
    {
        public ReturnRequest()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        public int CreatedById { get; set; }
        [Required]
        public string Reason { get; set; }
        [Required]
        public DateTime CreatedOnUtc { get; set; }

        [Required]
        [ForeignKey("CreatedById")]
        public virtual User CreatedBy { get; set; }
        [Required]
        public virtual Offer Offer { get; set; }
    }
}
