using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerProject.Entity.DateConfigurations;

namespace SchedulerProject.UtilsDate
{
    public class DateValidator
    {
        public static bool DateRangeValidator(DateTimeOffset date, LimitsConfigurations limits)
        {
            return limits.EndDate == null || date <= limits.EndDate;
        }
    }
}