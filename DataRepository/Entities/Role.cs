﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Entities
{
    public class Role : BaseEntity
    {

        [Required]
        public string Name { get; set; }

        [Required]
        public int AreaId { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
