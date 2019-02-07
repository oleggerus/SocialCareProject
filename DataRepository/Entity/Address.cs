using System;
using System.ComponentModel.DataAnnotations;
using DataRepository.Entity.People;

namespace DataRepository.Entity
{
    public class Address : BaseEntity
    {
        public Address()
        {
            CreatedOnUtc = DateTime.UtcNow;
        }
        public string HouseNameRoomNumber { get; set; }
        public string Street { get; set; }

        public string Email { get; set; }
        [Required]
        public int RegionId { get; set; }
        [Required]
        public string City { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public bool Deleted { get; set; }
        [Required]
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? UpdatedOnUtc { get; set; }


        public virtual User CreatedBy { get; set; }
        public virtual User UpdatedBy { get; set; }

        public object Clone()
        {
            var address = new Address
            {

                Email = Email,
                City = City,
                ZipPostalCode = ZipPostalCode,
                PhoneNumber = PhoneNumber,
                CreatedOnUtc = CreatedOnUtc,
                UpdatedOnUtc = UpdatedOnUtc,
                Deleted = Deleted,
            };
            return address;
        }

    }
}
