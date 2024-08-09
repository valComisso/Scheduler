using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Entity.Results;
using SchedulerProject.Enums;
using SchedulerProject.Services.Descriptions;
using SchedulerProject.Services.RecurringDates;
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

            if (configurations.Type == EventType.Once) return GenerateDescriptionService.AddMessages([nextDateAvailable], nextDateAvailable, configurations);

            var nextDates = RecurringDatesService.GetNextAvailableDates(configurations, nextDateAvailable, limitOccurrences);

            return GenerateDescriptionService.AddMessages(nextDates, nextDateAvailable, configurations);

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

    }
}
