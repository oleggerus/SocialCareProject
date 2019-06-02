using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entities
{
    public class Notification : BaseEntity
    {
        public string Text { get; set; }
        public int UserId { get; set; }
        public bool IsOpened { get; set; }
        public bool IsPositive { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }

}
