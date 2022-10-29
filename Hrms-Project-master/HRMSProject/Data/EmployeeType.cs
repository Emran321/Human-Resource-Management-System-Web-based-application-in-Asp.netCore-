using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class EmployeeType
    {
        public EmployeeType()
        {
            Employees = new HashSet<Employee>();
        }

        public int EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; }
        public string OverTimeAllowed { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
