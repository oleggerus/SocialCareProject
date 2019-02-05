using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class ProductSchedule: BaseEntity
    {
        [Required]
        public bool IsRecurring { get; set; }
        [Required]
        public bool BasedOnWeek{ get; set; }
        public int? NumberOfCycles { get; set; }
        public int NumberOfWeeksForRepeating { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public bool AvailableOnMonday { get; set; }

        [Required]
        public bool AvailableOnTuesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Wednesday
        /// </summary>
        [Required]
        public bool AvailableOnWednesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Thursday
        /// </summary>
        [Required]
        bool AvailableOnThursday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Friday
        /// </summary>
        [Required]
        public bool AvailableOnFriday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Saturday
        /// </summary>
        [Required]
        public bool AvailableOnSaturday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Sunday
        /// </summary>
        [Required]
        public bool AvailableOnSunday { get; set; }
    }
}
