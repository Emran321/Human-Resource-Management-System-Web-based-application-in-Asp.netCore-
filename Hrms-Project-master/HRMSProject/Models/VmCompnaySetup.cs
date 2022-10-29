using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmCompnaySetup
    {
        [Display(Name = "Company ID")]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        [Required(ErrorMessage = "Please Enter Your Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Your Company Address ")]
        public string Address { get; set; }
        [Display(Name = "Company Start Date")]
        [DataType(DataType.Date)]
        public DateTime? CompanyStartDate { get; set; }
        [Display(Name = "Registration No")]
        [Required(ErrorMessage = "Please Enter Your Company Registration No")]
        public string RegistrationNo { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Please Enter Your Company Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Your Company Email")]
        public string Email { get; set; }
        public string Fax { get; set; }
        [Display(Name = "Company Type")]
        [Required(ErrorMessage = "Please Enter Your Company Type")]
        public int? CompanyTypeId { get; set; }
    }
}
