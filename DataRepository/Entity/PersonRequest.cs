using System.Security.AccessControl;

namespace DataRepository.Entity
{
    public class PersonRequest : BaseEntity
    {
        public string Description { get; set; }
        public int StatusId { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
