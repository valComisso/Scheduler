using SchedulerProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class MonthlyConfigurations
    {
        public MonthlyConfigurationsType Type { get; set; }
        public int? Every { get; set; }
        public uint? DayNumber { get; set; }
        public DayType DayType { get; set; }
        public MonthlyFrequency Frequency { get; set; }

    }
}
