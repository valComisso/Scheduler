using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services.RecurringDates.ProcessInterval
{
    public static class ProcessIntervalDaily
    {
        public static void ProcessInterval(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations,
            DateTimeOffset referenceDate, DateTimeOffset endOfProcess)
        {
            for (var date = referenceDate; date <= endOfProcess; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                AddTimesToDatesService.AddAvailableTimesForDay(date, ref count, availableDates, configurations);
            }
        }
    }
}
