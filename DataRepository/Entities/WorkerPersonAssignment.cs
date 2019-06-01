using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int WorkerId { get; set; }
        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("WorkerId")]
        public virtual Worker Worker { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public int ReviewedByUserId { get; set; }
    }
}
