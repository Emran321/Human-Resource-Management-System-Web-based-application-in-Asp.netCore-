using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class MaritialStatus
    {
        public MaritialStatus()
        {
            Employees = new HashSet<Employee>();
        }

        public int MaritialStatusId { get; set; }
        public string MaritialStatusName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
