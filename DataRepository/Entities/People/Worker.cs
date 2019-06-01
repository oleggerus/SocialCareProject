using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Entities.People
{
    public class Worker : BaseEntity
    {
        [Required]
        //0 if social worker
        public int PositionId { get; set; }
        [Required]
        public bool IsLead { get; set; }
        public int? StatusId { get; set; }
        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        [Required]
        public virtual Administration Administration { get; set; }
        
    }
}
