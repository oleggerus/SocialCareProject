﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entities.People
{
    public class CareRequest : BaseEntity
    {
        public CareRequest()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }
        [Required]
        public string Reason { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public DateTime CreatedOnUtc { get; set; }


        [ForeignKey("CustomerId")]
        public Customer Customer{ get; set; }
    }
}
