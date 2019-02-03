using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Offer : BaseEntity
    {
        public int? ProductId { get; set; }   
        /// <summary>
        /// approved, declined or not reviewed
        /// </summary>
        public int StatusId{ get; set; }
        public int? ReviewedById { get; set; }


        public int? CreatedById { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ReviewedOnUtc { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual User ReviewedBy { get; set; }


    }
}
