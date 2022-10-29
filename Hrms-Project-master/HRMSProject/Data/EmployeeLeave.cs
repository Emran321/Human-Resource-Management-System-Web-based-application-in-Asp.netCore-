using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class EmployeeLeave
    {
        public int EmplaoyeeLeaveId { get; set; }
        public int? EmployeeId { get; set; }
        public int? LeaveTypeId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? TotalDays { get; set; }
        public string Status { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual LeaveType LeaveType { get; set; }
    }
}
