using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services.RecurringDates.ProcessInterval;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services.RecurringDates
{
    public static class RecurringDatesService
    {
        public static List<DateTimeOffset> GetNextAvailableDates(DateConfigurations configurations, DateTimeOffset startDate, int? limitOccurrences = null)
        {
            var availableDates = new List<DateTimeOffset>();
            var referenceDate = startDate;
            var count = 0;
            var limit = limitOccurrences ?? int.MaxValue;
            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;

            while (count < limit && referenceDate <= endDate)
            {
                referenceDate = ProcessInterval(referenceDate, ref count, availableDates, configurations);
                referenceDate = IntervalCalculator.GetNextIntervalStart(referenceDate, configurations);
            }

            return availableDates;
        }

        private static DateTimeOffset ProcessInterval(
            DateTimeOffset referenceDate,
            ref int count,
            List<DateTimeOffset> availableDates,
            DateConfigurations configurations
        )
        {
            var daysProcess = GetDaysToProcess(referenceDate, configurations.Occurrence);
            var endOfProcess = referenceDate.AddDays(daysProcess);


            switch (configurations.Occurrence)
            {
                case OccurrenceType.Daily:
                    ProcessIntervalDaily.ProcessInterval(ref count, availableDates, configurations, referenceDate, endOfProcess);
                    break;
                case OccurrenceType.Weekly:
                    ProcessIntervalWeekly.ProcessInterval(ref count, availableDates, configurations, referenceDate, endOfProcess);
                    break;
                case OccurrenceType.Monthly:
                default:
                    ProcessIntervalMonthly.ProcessInterval(ref count, availableDates, configurations, referenceDate);
                    break;
            }
            return endOfProcess;
        }

        private static int GetDaysToProcess(DateTimeOffset referenceDate, OccurrenceType occurrence)
        {
            return occurrence switch
            {
                OccurrenceType.Daily => 0,
                OccurrenceType.Weekly => 7 - (int)referenceDate.DayOfWeek,
                OccurrenceType.Monthly => DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month) - referenceDate.Day,
                _ => 0
            };
        }



    }
}
