using System;

namespace DataRepository.Entity
{
    public class Address : BaseEntity
    {
        public string HouseNameRoomNumber { get; set; }
        public string Email { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; }
        public string ZipPostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool Deleted { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
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
                UpdatedById = UpdatedById
            };
            return address;
        }

    }
}
