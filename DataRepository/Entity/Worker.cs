﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Worker : BaseEntity
    {
        public int UserId { get; set; }
        public int? AdministrationId { get; set; }
        public string Position { get; set; }
        public bool IsLead { get; set; }
        public int? StatusId { get; set; }


        public virtual User User { get; set; }
        public virtual Administration Administration { get; set; }
    }
}
