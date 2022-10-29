using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class CompanySetup
    {
        public CompanySetup()
        {
            Branches = new HashSet<Branch>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public DateTime? CompanyStartDate { get; set; }
        public string RegistrationNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public int? CompanyTypeId { get; set; }

        public virtual CompanyType CompanyType { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
