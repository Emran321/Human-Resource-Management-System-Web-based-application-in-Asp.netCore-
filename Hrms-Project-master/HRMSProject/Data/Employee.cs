using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Employee
    {
        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            EmployeeLeaves = new HashSet<EmployeeLeave>();
            EmployeeOverTimeRates = new HashSet<EmployeeOverTimeRate>();
            EmployeeWiseOverTimeHours = new HashSet<EmployeeWiseOverTimeHour>();
            Salaries = new HashSet<Salary>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string PresentAddress { get; set; }
        public string ParmanentAddress { get; set; }
        public int? DepartmentId { get; set; }
        public int? DesignationId { get; set; }
        public int? GradeId { get; set; }
        public int? ShiftId { get; set; }
        public int? EmployeeTypeId { get; set; }
        public int? NationalityId { get; set; }
        public int? ReligionId { get; set; }
        public int? MaritialStatusId { get; set; }

        public virtual Department Department { get; set; }
        public virtual Designation Designation { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual MaritialStatus MaritialStatus { get; set; }
        public virtual Nationality Nationality { get; set; }
        public virtual Religion Religion { get; set; }
        public virtual Shift Shift { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<EmployeeLeave> EmployeeLeaves { get; set; }
        public virtual ICollection<EmployeeOverTimeRate> EmployeeOverTimeRates { get; set; }
        public virtual ICollection<EmployeeWiseOverTimeHour> EmployeeWiseOverTimeHours { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
    }
}
