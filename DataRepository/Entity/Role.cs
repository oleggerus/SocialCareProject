using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public int AreaId { get; set; }
    }
}
