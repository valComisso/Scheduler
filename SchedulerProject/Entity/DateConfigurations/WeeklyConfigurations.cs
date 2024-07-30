using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class WeeklyConfigurations
    {
        public List<DayOfWeek> SelectedDays { get; set; } = SetAllowedDays.DefineAllowedDaysOfTheWeek(null);
    }
}