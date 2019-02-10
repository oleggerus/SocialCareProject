using System;
using System.ComponentModel.DataAnnotations;
using DataRepository.Entities.People;

namespace DataRepository.Entities
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
