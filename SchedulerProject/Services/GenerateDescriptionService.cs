using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using System.Text;

namespace SchedulerProject.Services
{
    public static class GenerateDescriptionService
    {
        public static string GenerateRecurringMessage(DateConfigurations configurations, DateTimeOffset date)
        {
            var message = WeeklyConfigurationText(configurations) + FrequencyDailyText(configurations) + $". Starting on {date}.";

            return message;
        }

        private static string WeeklyConfigurationText(DateConfigurations configurations)
        {
            var every = configurations.Every;
            var occurrence = configurations.Occurrence == OccurrenceType.Daily? "day": "week";
            var days = configurations.WeeklyConfigurations.SelectedDays;

            var messageOccurs = $"Occurs every {every} {occurrence}{(every > 1 ? "s" : string.Empty)}";

            var messageSelectedDays = days.Count == 7
                ? "all days."
                : string.Join(", ", days.Take(days.Count - 1)) + (days.Count > 1 ? " and " : string.Empty) + days.Last();

            return $"{messageOccurs} on {messageSelectedDays}";
        }

        private static string FrequencyDailyText(DateConfigurations configurations)
        {
            var type = configurations.FrequencyConfigurations!.Type;
     
            switch (type)
            {
                case DailyFrequencyType.Fixed:
                    return $" at {configurations.FrequencyConfigurations.FixedTime}";
                case DailyFrequencyType.Variable:
                {
                    var start = configurations.FrequencyConfigurations.StartTime;
                    var end = configurations.FrequencyConfigurations.EndTime;
                    var every = configurations.FrequencyConfigurations.Every;
                    var everyType = GetEventTypeText(configurations.FrequencyConfigurations.EveryType, every);
                    return $" every {every} {everyType} between {start} and {end}";
                }
                default:
                    return string.Empty;
            }
        }

        private static string GetEventTypeText(EveryType type, int? every)
        {
            var eventTypes = new Dictionary<EveryType, (string singular, string plural)>
            {
                { EveryType.Hours, ("hour", "hours") },
                { EveryType.Minutes, ("minute", "minutes") },
                { EveryType.Seconds, ("second", "seconds") }
            };

            var eventType = eventTypes[type];

            return every == 1 ? eventType.singular : eventType.plural;
        }

    }
}
