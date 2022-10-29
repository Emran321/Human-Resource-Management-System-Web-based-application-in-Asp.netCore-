using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Religion
    {
        public Religion()
        {
            Employees = new HashSet<Employee>();
        }

        public int ReligionId { get; set; }
        public string ReligionName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
