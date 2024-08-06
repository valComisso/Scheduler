
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class WeeklyConfigurations
    {
        public List<DayOfWeek> SelectedDays { get; set; } = SetAllowedDays.DefineAllowedDaysOfTheWeek(null);
    }
}