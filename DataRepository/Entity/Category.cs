using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
