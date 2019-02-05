using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Worker : BaseEntity
    {
        [Required]
        public int PositionId { get; set; }
        [Required]
        public bool IsLead { get; set; }
        public int? StatusId { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Administration Administration { get; set; }


    }
}
