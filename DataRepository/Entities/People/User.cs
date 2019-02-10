using System;
using System.ComponentModel.DataAnnotations;

namespace DataRepository.Entities.People
{
    public class User : BaseEntity
    {
        public User()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordSalt { get; set; }
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

    }
}
