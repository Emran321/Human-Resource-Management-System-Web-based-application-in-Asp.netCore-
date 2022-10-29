using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class SalaryBreakeDown
    {
        public int BreakdownId { get; set; }
        public int? GradeId { get; set; }
        public int? SalaryHeadId { get; set; }
        public decimal? Amount { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual SalaryHead SalaryHead { get; set; }
    }
}
