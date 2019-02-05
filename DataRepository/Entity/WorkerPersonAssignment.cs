using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class WorkerPersonAssignment : BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; }
        public int StatusId { get; set; }

        
        public virtual Worker Worker { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Worker ApprovedBy { get; set; }

        public virtual Administration Administration { get; set; }

    }
}
