using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public int AdministrationId { get; set; }
        public int AddressId { get; set; }
        public string Info { get; set; }
        public bool? IsSelfPaid { get; set; }
        public bool? IsInvalid { get; set; }
        public int? StatusId { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual Address Address { get; set; }       
        public virtual User User { get; set; }
        public virtual Administration Administration { get; set; }
    }
}
