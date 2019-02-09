using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using DataRepository.Entity.People;

namespace DataRepository.Entity
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
