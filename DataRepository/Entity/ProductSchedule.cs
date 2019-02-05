using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.Entity
{
    public class ProductSchedule: BaseEntity
    {
        public bool IsRecurring { get; set; }
        public bool BasedOnWeek{ get; set; }
        public int? NumberOfCycles { get; set; }
        public int NumberOfWeeksForRepeating { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public bool AvailableOnMonday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Tuesday
        /// </summary>
        public bool AvailableOnTuesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Wednesday
        /// </summary>
        public bool AvailableOnWednesday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Thursday
        /// </summary>
        public bool AvailableOnThursday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Friday
        /// </summary>
        public bool AvailableOnFriday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Saturday
        /// </summary>
        public bool AvailableOnSaturday { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the service/advice is available on Sunday
        /// </summary>
        public bool AvailableOnSunday { get; set; }
    }
}
