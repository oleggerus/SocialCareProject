using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entity.People;

namespace DataRepository.Entity
{
    public class Vendor : BaseEntity
    {
        public Vendor()
        {
            CreatedOnUtc = DateTime.UtcNow;;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Url { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        public byte[] Logo { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; } 
        [Required]
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        [Required]
        public virtual Address Address { get; set; }
        
        public virtual Provider Contact { get; set; }
        public virtual User CreatedBy{ get; set; }
        public virtual User UpdatedBy { get; set; }

        [InverseProperty("Vendor")]
        public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
    }
}
