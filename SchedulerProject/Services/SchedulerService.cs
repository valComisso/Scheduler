using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Entity.Results;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;
using SchedulerProject.Validator;

namespace SchedulerProject.Services
{
    public static class SchedulerService
    {
        public static List<DateResult> GetUpcomingAvailableDates(DateConfigurations configurations, int? limitOccurrences = null)
        {
            ValidateConfigurations.ValidateTheCompleteConfiguration(configurations);

            var nextDateAvailable = GetReferenceDate(configurations);

            if (configurations.Type == EventType.Once) return GenerateUpcomingResultsAvailableDates([nextDateAvailable], nextDateAvailable, configurations);

            var nextDates = RecurringDatesService.GetNextAvailableDates(configurations, nextDateAvailable, limitOccurrences);
            return GenerateUpcomingResultsAvailableDates(nextDates, nextDateAvailable, configurations);

        }

        private static DateTimeOffset GetReferenceDate(DateConfigurations configurations)
        {
            var type = configurations.Type;
            var currentDate = configurations.CurrentDate;
            var dateTimeSettings = configurations.DateTimeSettings;

            var referenceDate = type switch
            {
                EventType.Once => dateTimeSettings > currentDate ? dateTimeSettings.Value : currentDate.AddDays(1),
                EventType.Recurring => currentDate,
                _ => default
            };
            if (!DateValidator.DateRangeValidator(referenceDate, configurations.Limits))
            {
                throw new ArgumentException("The reference date is not within the allowed range.");
            }

            var nextDate = referenceDate < configurations.Limits.StartDate ? configurations.Limits.StartDate : referenceDate;

            return nextDate;
        }



        public static List<DateResult> GenerateUpcomingResultsAvailableDates(List<DateTimeOffset> dates,
            DateTimeOffset referenceDate, DateConfigurations configurations)
        {

            var type = configurations.Type;
            var startDate = configurations.Limits.StartDate;

            var message = configurations.Type switch
            {
                EventType.Recurring => $"Occurs {type}. Starting on {startDate}.",
                EventType.Once =>
                    $"Occurs {type}. Schedule will be used on {referenceDate} starting on {startDate}.",
                _ => ""
            };

            return dates.Select(date => new DateResult(message, date)).ToList();
        }
    }
}
