using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Nationality
    {
        public Nationality()
        {
            Employees = new HashSet<Employee>();
        }

        public int NationalityId { get; set; }
        public string NationalityName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
