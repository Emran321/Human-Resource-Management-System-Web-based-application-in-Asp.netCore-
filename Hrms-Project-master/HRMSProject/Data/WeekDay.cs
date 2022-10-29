using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSProject.Data
{
    public partial class WeekDay
    {
        public int WeekDaysId { get; set; }
        public string DayName { get; set; }
        public bool? IworkingDay { get; set; }
    }
}
