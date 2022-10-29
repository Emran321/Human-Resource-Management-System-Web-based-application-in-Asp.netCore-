using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class EmployeeOverTimeRate
    {
        public int EmployeeOverTimeRateId { get; set; }
        public int? EmployeeId { get; set; }
        public string Days { get; set; }
        public string RateAmount { get; set; }
        public int? OverTimeRateId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual OverTimeRate OverTimeRate { get; set; }
    }
}
