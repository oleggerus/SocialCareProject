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

        public int WorkerId { get; set; }
        public int CustomerId { get; set; }

        [Required]
        public virtual Worker Worker { get; set; }
        [Required]
        //[ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        [Required]
        //[ForeignKey("WorkerId")]
        public virtual Worker ApprovedBy { get; set; }
    }
}
