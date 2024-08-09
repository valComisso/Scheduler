using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using System.Text;

namespace SchedulerProject.Services.Descriptions
{
    public static class GenerateDescriptionRecurring
    {
        public static string GenerateMessage(DateConfigurations configurations, DateTimeOffset date)
        {
            var message = new StringBuilder();

            message.Append("Occurs");

            AppendMonthlyConfigurationText(message, configurations);
            AppendOccurrenceText(message, configurations);
            AppendDaysIfNotMonthly(message, configurations);
            AppendFrequencyDailyText(message, configurations);

            message.Append($". Starting on {date}.");

            return message.ToString();
        }
        private static void AppendMonthlyConfigurationText(StringBuilder message, DateConfigurations configurations)
        {
            if (configurations.Occurrence == OccurrenceType.Monthly)
            {
                message.Append(MonthlyConfigurationText(configurations));
            }
        }

        private static void AppendOccurrenceText(StringBuilder message, DateConfigurations configurations)
        {
            var occurrenceText = AppendOccurrence(configurations.Every, configurations.Occurrence);
            message.Append(occurrenceText);
        }

        private static void AppendDaysIfNotMonthly(StringBuilder message, DateConfigurations configurations)
        {
            if (configurations.Occurrence != OccurrenceType.Monthly)
            {
                var daysText = AppendDays(configurations.WeeklyConfigurations.SelectedDays);
                message.Append(daysText);
            }
        }

        private static void AppendFrequencyDailyText(StringBuilder message, DateConfigurations configurations)
        {
            var frequencyText = FrequencyDailyText(configurations);
            message.Append(frequencyText);
        }


        private static string MonthlyConfigurationText(DateConfigurations configurations)
        {
            var type = configurations.MonthlyConfigurations!.Type;

            if (type == MonthlyConfigurationsType.The)
            {
                var frequency = configurations.MonthlyConfigurations!.Frequency;
                var dayType = configurations.MonthlyConfigurations!.DayType;

                return $" the {frequency} {dayType}";
            }

            var day = configurations.MonthlyConfigurations.DayNumber;
            
            return $" on the {day}th";
        }

        private static string AppendOccurrence(uint? every, OccurrenceType occurrenceType)
        {

            var messageBuilder = new StringBuilder();

            var occurrenceMapping = new Dictionary<OccurrenceType, string>
            {
                { OccurrenceType.Daily, "day" },
                { OccurrenceType.Weekly, "week" },
                { OccurrenceType.Monthly, "month" }
            };

            if (!occurrenceMapping.TryGetValue(occurrenceType, out var occurrence))
            {
                throw new ArgumentException("Unsupported occurrence type");
            }

            messageBuilder.Append($" every {every} {occurrence}");

            if (every > 1)
            {
                messageBuilder.Append("s");
            }

            return messageBuilder.ToString();
        }

        private static string AppendDays(List<DayOfWeek> days)
        {
            return days.Count switch
            {
                7 => " on all days.",
                _ => $" on {string.Join(", ", days.Take(days.Count - 1))}" +
                     (days.Count > 1 ? " and " : string.Empty) + days.Last()
            };
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
