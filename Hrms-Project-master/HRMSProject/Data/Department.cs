using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int? BranchId { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
