using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataRepository.Entities.People;

namespace DataRepository.Entities.Orders
{
    public class PersonRequest : BaseEntity
    {
        public PersonRequest()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        [Required]
        public string Description { get; set; }
        [Required]
        public string Name{ get; set; }

        [Required]
        public int StatusId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public int CreatedById { get; set; }

        [ForeignKey("CreatedById")]
        public virtual Customer CreatedBy { get; set; }

        [Required]
        public virtual Category Category { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
