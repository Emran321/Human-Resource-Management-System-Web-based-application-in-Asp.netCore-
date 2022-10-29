using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Grade
    {
        public Grade()
        {
            Employees = new HashSet<Employee>();
            SalaryBreakeDowns = new HashSet<SalaryBreakeDown>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public decimal? GradeSalary { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<SalaryBreakeDown> SalaryBreakeDowns { get; set; }
    }
}
