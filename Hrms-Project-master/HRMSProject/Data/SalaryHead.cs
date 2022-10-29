using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class SalaryHead
    {
        public SalaryHead()
        {
            SalaryBreakeDowns = new HashSet<SalaryBreakeDown>();
            SalaryRoles = new HashSet<SalaryRole>();
        }

        public int SalaryHeadId { get; set; }
        public string SalaryHeadName { get; set; }
        public string SalaryHeadType { get; set; }

        public virtual ICollection<SalaryBreakeDown> SalaryBreakeDowns { get; set; }
        public virtual ICollection<SalaryRole> SalaryRoles { get; set; }
    }
}
