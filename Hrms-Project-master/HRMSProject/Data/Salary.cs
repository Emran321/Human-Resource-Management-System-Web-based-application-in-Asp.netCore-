using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Salary
    {
        public int SalaryId { get; set; }
        public int? EmployeeId { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
        public int? TotalPresent { get; set; }
        public int? TotalAbsent { get; set; }
        public int? TotalLeave { get; set; }
        public int? TotalLate { get; set; }
        public DateTime? OvertimeHour { get; set; }
        public int? TotalCountablePresent { get; set; }
        public decimal? TotalSalary { get; set; }
        public decimal? OverTime { get; set; }
        public decimal? GrandTotal { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
