using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class Gender
    {
        public Gender()
        {
            LeaveTypes = new HashSet<LeaveType>();
        }

        public int GenderId { get; set; }
        public string GenderName { get; set; }

        public virtual ICollection<LeaveType> LeaveTypes { get; set; }
    }
}
