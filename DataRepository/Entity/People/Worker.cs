using System.ComponentModel.DataAnnotations;

namespace DataRepository.Entity.People
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
