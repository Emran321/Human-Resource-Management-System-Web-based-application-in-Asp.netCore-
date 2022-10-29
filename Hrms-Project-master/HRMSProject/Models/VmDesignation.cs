using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class VmDesignation
    {
        [Display(Name = "Designation ID")]
        public int DesignationId { get; set; }
        [Display(Name = "Designation type")]
        [Required(ErrorMessage = "Please Enter Designation Name")]
        public string DesignationName { get; set; }
    }
}
