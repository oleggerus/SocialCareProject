using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entity.People;

namespace DataRepository.Entity
{
    public class WorkerPersonAssignment : BaseEntity
    {
        public WorkerPersonAssignment()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        [Required]
        public DateTime CreatedOnUtc { get; set; }
        [Required]
        public int AssignmentStatusId { get; set; }

        [Required]
        public virtual Worker Worker { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public virtual Worker ApprovedBy { get; set; }
    }
}
