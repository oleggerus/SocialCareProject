﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class Customer : BaseEntity
    {
        [Required]
        public int AdministrationId { get; set; }

        public string Info { get; set; }
        [Required]
        public bool? IsSelfPaid { get; set; }
        [Required]
        public bool? IsInvalid { get; set; }
        [Required]
        public int? StatusId { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }
        [Required]
        public virtual Address Address { get; set; }
        [Required]
        public virtual User User { get; set; }
        
        [ForeignKey("AdministrationId")]
        public virtual Administration Administration { get; set; }

    }
}
