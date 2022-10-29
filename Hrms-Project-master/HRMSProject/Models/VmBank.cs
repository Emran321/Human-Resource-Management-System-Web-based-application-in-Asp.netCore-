using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmBank
    {
        [Display(Name = "Bank ID")]
        public int BankId { get; set; }

        [Display(Name = "Bank Name")]
        [Required(ErrorMessage = "Please Enter Bank Name")]
        public string BankName { get; set; }
    }
}
