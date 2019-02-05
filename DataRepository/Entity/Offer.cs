using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Offer : BaseEntity
    {
        /// <summary>
        /// approved, declined or not reviewed
        /// </summary>
        public int StatusId{ get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime ReviewedOnUtc { get; set; }

        public virtual Customer Customer{ get; set; }

        public virtual Provider CreatedBy { get; set; }
        public virtual User ReviewedBy { get; set; }
        public virtual Product Product{ get; set; }


    }
}
