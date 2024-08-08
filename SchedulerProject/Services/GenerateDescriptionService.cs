using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using System.Text;

namespace SchedulerProject.Services
{
    public static class GenerateDescriptionService
    {
        public static string GenerateRecurringMessage(DateConfigurations configurations, DateTimeOffset date)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.Append(WeeklyConfigurationText(configurations));
            messageBuilder.Append(FrequencyDailyText(configurations));
            messageBuilder.Append($". Starting on {date}.");

            return messageBuilder.ToString();
        }

        private static string WeeklyConfigurationText(DateConfigurations configurations)
        {
            var messageBuilder = new StringBuilder();

            AppendOccurrence(messageBuilder, configurations.Every, configurations.Occurrence);
            AppendDays(messageBuilder, configurations.WeeklyConfigurations.SelectedDays);

            return messageBuilder.ToString();
        }

        private static void AppendOccurrence(StringBuilder messageBuilder, uint? every, OccurrenceType occurrenceType)
        {
            var occurrence = occurrenceType == OccurrenceType.Daily ? "day" : "week";
            messageBuilder.Append($"Occurs every {every} {occurrence}");
            if (every > 1)
            {
                messageBuilder.Append("s");
            }
        }
        private static void AppendDays(StringBuilder messageBuilder, List<DayOfWeek> days)
        {
            messageBuilder.Append(" on ");

            if (days.Count == 7)
            {
                messageBuilder.Append("all days.");
            }
            else
            {
                messageBuilder.Append(string.Join(", ", days.Take(days.Count - 1)));
                if (days.Count > 1)
                {
                    messageBuilder.Append(" and ");
                }
                messageBuilder.Append(days.Last());
            }
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
