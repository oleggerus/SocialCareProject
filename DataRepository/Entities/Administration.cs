using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataRepository.Entities.People;

namespace DataRepository.Entities
{
    public class Administration : BaseEntity
    {
        public Administration()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Url { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] Logo { get; set; }

        [Required]
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        public virtual User Contact { get; set; }

        [InverseProperty("Administration")]
        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

        [InverseProperty("Administration")]
        public virtual ICollection<Worker> Workers { get; set; } = new List<Worker>();

    }
}
