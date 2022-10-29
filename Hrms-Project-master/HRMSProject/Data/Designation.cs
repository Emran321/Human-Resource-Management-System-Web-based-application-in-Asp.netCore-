using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Designation
    {
        public Designation()
        {
            Employees = new HashSet<Employee>();
        }

        public int DesignationId { get; set; }
        public string DesignationName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
