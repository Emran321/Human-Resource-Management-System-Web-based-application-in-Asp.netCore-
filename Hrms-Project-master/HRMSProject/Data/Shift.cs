using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Shift
    {
        public Shift()
        {
            Employees = new HashSet<Employee>();
        }

        public int ShiftId { get; set; }
        public string ShiftName { get; set; }
        public DateTime? ShiftStartTime { get; set; }
        public DateTime? ShiftEndTime { get; set; }
        public string TotalTime { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
