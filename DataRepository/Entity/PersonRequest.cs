using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using DataRepository.Entity.People;

namespace DataRepository.Entity
{
    public class PersonRequest : BaseEntity
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public int StatusId { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
    }
}
