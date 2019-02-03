using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class WorkerPersonAssignment : BaseEntity
    {
        public int WorkerId { get; set; }
        public int PersonId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual Worker Worker { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
