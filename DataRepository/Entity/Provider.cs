using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Provider:BaseEntity
    {

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }


        public virtual Address Address { get; set; }
        public virtual User UserId { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
