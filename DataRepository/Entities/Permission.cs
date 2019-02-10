using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Entities
{
    public class Permission : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [InverseProperty("Permissions")]
        public virtual Role Role { get; set; } 
    }
}
