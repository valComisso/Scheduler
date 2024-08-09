using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services.RecurringDates.ProcessInterval
{
    public static class ProcessIntervalWeekly
    {
        public static void ProcessInterval(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations,
            DateTimeOffset referenceDate, DateTimeOffset endOfProcess)
        {
            for (var date = referenceDate; date <= endOfProcess; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                var requiredDaysList = SetAllowedDays.DefineAllowedDaysOfTheWeek(configurations.WeeklyConfigurations.SelectedDays);

                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddTimesToDatesService.AddAvailableTimesForDay(date, ref count, availableDates, configurations);
            }
        }
    }
}
