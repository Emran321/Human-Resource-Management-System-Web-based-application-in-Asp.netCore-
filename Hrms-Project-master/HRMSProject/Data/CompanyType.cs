using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class CompanyType
    {
        public CompanyType()
        {
            CompanySetups = new HashSet<CompanySetup>();
        }

        public int CompanyTypeId { get; set; }
        public string CompanyTypeName { get; set; }

        public virtual ICollection<CompanySetup> CompanySetups { get; set; }
    }
}
