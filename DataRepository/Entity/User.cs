using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataRepository.Entity
{
    public class User : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int? NoAttempts { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public bool IsMale { get; set; }
        public byte[] Avatar { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        [Required]
        public virtual Role Role { get; set; }
        //[InverseProperty("User")]
        //public virtual Customer Customer{ get; set; }
        //[InverseProperty("User")]
        //public virtual Worker Worker { get; set; }
        //[InverseProperty("User")]
        //public virtual Provider Provider { get; set; }

    }
}
