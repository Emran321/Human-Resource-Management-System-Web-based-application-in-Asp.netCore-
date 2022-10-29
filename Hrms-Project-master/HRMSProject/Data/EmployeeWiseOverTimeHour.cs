using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class EmployeeWiseOverTimeHour
    {
        public int EmployeeWiseOverTimeHourId { get; set; }
        public DateTime? Date { get; set; }
        public int? Hour { get; set; }
        public int? EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
