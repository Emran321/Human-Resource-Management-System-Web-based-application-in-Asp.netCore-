using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class GeneralOverTimeHour
    {
        public int GeneralOverTimeHourId { get; set; }
        public DateTime? Date { get; set; }
        public int? Hour { get; set; }
    }
}
