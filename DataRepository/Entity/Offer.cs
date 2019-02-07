﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository.Entity.People;

namespace DataRepository.Entity
{
    public class Offer : BaseEntity
    {
        public int CreatedById { get; set; }

        /// <summary>
        /// approved, declined or not reviewed
        /// </summary>
        [Required]
        public int StatusId{ get; set; }
        public string Description { get; set; }
        [Required]   
        public bool IsDeleted { get; set; }
        [Required]
        public DateTime CreatedOnUtc { get; set; }
        public DateTime ReviewedOnUtc { get; set; }
        [Required]
        public virtual Customer Customer{ get; set; }
        [Required]
        [ForeignKey("CreatedById")]
        public virtual Provider CreatedBy { get; set; }
        public virtual User ReviewedBy { get; set; }
        [Required]
        public virtual Product Product{ get; set; }


    }
}
