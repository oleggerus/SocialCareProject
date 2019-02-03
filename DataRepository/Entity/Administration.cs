using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Administration : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public string Url { get; set; }
        public int ContactId{ get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte[] Logo { get; set; }


        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }

        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        public virtual Address Address { get; set; }
        public virtual User Contact { get; set; }


        public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
        public virtual ICollection<Worker> Workers{ get; set; } = new List<Worker>();
    }
}
