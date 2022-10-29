using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class LeaveType
    {
        public LeaveType()
        {
            EmployeeLeaves = new HashSet<EmployeeLeave>();
        }

        public int LeaveTypeId { get; set; }
        public string LeaveTypeName { get; set; }
        public int? Days { get; set; }
        public int? GenderId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
    }
}
