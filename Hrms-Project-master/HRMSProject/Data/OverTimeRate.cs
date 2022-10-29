using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class OverTimeRate
    {
        public OverTimeRate()
        {
            EmployeeOverTimeRates = new HashSet<EmployeeOverTimeRate>();
        }

        public int OverTimeRateId { get; set; }
        public bool? IsWorkingDay { get; set; }
        public string Rate { get; set; }

        public virtual ICollection<EmployeeOverTimeRate> EmployeeOverTimeRates { get; set; }
    }
}
