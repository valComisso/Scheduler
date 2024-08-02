using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using System.Text;

namespace SchedulerProject.Services
{
    public class GenerateDescriptionService
    {
        public static string GenerateRecurringMessage(DateConfigurations configurations, DateTimeOffset date)
        {

            var message = WeeklyConfigurationText(configurations) + FrequencyDailyText(configurations) + $". Starting on {date}.";

            return message;
        }


        private static string WeeklyConfigurationText(DateConfigurations configurations)
        {
            var every = configurations.Every;
            var occurrence = configurations.Occurrence;
            var days = configurations.WeeklyConfigurations.SelectedDays;


            var messageOccurs = "";

            if (occurrence == OccurrenceType.Daily)
            {
                messageOccurs = every == 1 ? "Occurs every 1 day" : $"Occurs every {every} days";
            }
            else if (occurrence == OccurrenceType.Weekly)
            {
                messageOccurs = every == 1 ? "Occurs every 1 week" : $"Occurs every {every} weeks";
            }



            var messageSelectedDays = new StringBuilder();


            if (days.Count == 7)
            {
                messageSelectedDays.Append("all days. ");
            }
            else
            {
                for (var i = 0; i < days.Count; i++)
                {
                    if (i > 0 && i == days.Count - 1)
                    {
                        messageSelectedDays.Append($"and {days[i]} ");
                    }
                    else
                    {
                        messageSelectedDays.Append($"{days[i]} ");
                    }


                    if (i < days.Count - 2)
                    {
                        messageSelectedDays.Append(", ");
                    }
                }
            }


            return messageOccurs + " on " + messageSelectedDays;



        }

        private static StringBuilder FrequencyDailyText(DateConfigurations configurations)
        {
            var type = configurations.FrequencyConfigurations!.Type;
            var message = new StringBuilder();
            if (type == DailyFrequencyType.Fixed)
            {
                message.Append($"at {configurations.FrequencyConfigurations.FixedTime}");
            }
            else if (type == DailyFrequencyType.Variable)
            {

                var start = configurations.FrequencyConfigurations.StartTime;
                var end = configurations.FrequencyConfigurations.EndTime;
                var every = configurations.FrequencyConfigurations.Every;
                var everyType = GetEventTypeText(configurations.FrequencyConfigurations.EveryType, every);
                message.Append($"every {every} {everyType} between {start} and {end}");

            }

            return message;

        }

        private static string GetEventTypeText(EveryType type, int? every)
        {
            var eventTypes = new Dictionary<EveryType, (string singular, string plural)>
            {
                { EveryType.Hours, ("hour", "hours") },
                { EveryType.Minutes, ("minute", "minutes") },
                { EveryType.Seconds, ("second", "seconds") }
            };

            if (eventTypes.TryGetValue(type, out var eventType))
            {
                return every == 1 ? eventType.singular : eventType.plural;
            }

            throw new ArgumentOutOfRangeException(nameof(type), $"The type '{type}' is not recognized.");


        }
    }
}
