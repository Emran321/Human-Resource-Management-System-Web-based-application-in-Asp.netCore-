using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmEmployeeType
    {
        [Display(Name ="Employee ID")]
        public int EmployeeTypeId { get; set; }
        [Display(Name ="Employee Type")]
        [Required(ErrorMessage ="Please Enter Employee Type Name")]
        public string EmployeeTypeName { get; set; }
        [Display(Name = "OverTime Allowed")]
        [Required(ErrorMessage = "Please Enter OverTime Allowed")]
        public string OverTimeAllowed { get; set; }
    }
}
