using SchedulerProject.Entity.DateConfigurations;

namespace SchedulerProject.UtilsDate
{
    public static class DateValidator
    {
        public static bool DateRangeValidator(DateTimeOffset date, LimitsConfigurations limits)
        {
            return limits.EndDate == null || date <= limits.EndDate;
        }
    }
}