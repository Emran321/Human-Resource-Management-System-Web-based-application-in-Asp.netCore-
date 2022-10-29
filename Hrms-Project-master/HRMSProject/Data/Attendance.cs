using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public DateTime? LateTime { get; set; }
        public string TotalWorkingHour { get; set; }
        public string OverTimeHour { get; set; }
        public bool? IworkingDay { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
