using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Entity
{
    public class User : BaseEntity
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? NoAttempts { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool IsMale { get; set; }
        public byte[] Avatar { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }
        public virtual Role Role { get; set; }
    }
}
