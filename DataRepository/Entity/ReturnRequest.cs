using System;
using System.Globalization;

namespace DataRepository.Entity
{
    public class ReturnRequest : BaseEntity
    {
        public string Reason { get; set; }
        public DateTime CreatedOnUtc { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual Offer Offer{ get; set; }
    }
}
