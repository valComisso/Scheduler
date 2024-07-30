using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerProject.UtilsDate
{
    public class SetAllowedDays
    {
        public static List<DayOfWeek> DefineAllowedDaysOfTheWeek(List<DayOfWeek>? days)
        {
            return days ??
            [
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            ];
        }
    }
}