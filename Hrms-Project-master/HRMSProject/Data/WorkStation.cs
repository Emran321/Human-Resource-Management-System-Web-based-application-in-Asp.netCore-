using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class WorkStation
    {
        public int WorkStationId { get; set; }
        public string WorkStationName { get; set; }
        public string Location { get; set; }
        public int? BranchId { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
