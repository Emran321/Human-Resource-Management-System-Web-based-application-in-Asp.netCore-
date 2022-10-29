using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class SalaryRole
    {
        public int SalaryRoleId { get; set; }
        public int? GradeId { get; set; }
        public int? SalaryHeadId { get; set; }
        public decimal? Formula { get; set; }

        public virtual SalaryHead SalaryHead { get; set; }
    }
}
