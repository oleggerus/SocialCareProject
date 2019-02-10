using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Entities.Orders
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
