using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmCompanyType
    {
        [Display(Name = "CompanyType ID")]
        public int CompanyTypeId { get; set; }
        [Display(Name = "Company Type")]
        [Required(ErrorMessage = "Please Enter Company Type Name")]
        public string CompanyTypeName { get; set; }
    }
}
