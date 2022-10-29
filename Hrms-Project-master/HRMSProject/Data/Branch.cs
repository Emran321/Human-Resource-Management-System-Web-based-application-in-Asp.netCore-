using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Branch
    {
        public Branch()
        {
            Departments = new HashSet<Department>();
            WorkStations = new HashSet<WorkStation>();
        }

        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string BranchLocation { get; set; }
        public int? CompanyId { get; set; }

        public virtual CompanySetup Company { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
        public virtual ICollection<WorkStation> WorkStations { get; set; }
    }
}
