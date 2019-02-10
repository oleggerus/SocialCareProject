using System.ComponentModel.DataAnnotations;
using DataRepository.Entities.People;

namespace DataRepository.Entities.Orders
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
