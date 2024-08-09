using SchedulerProject.Entity.DateConfigurations;

namespace SchedulerProject.Services.Descriptions
{
    internal class GenerateDescriptionDaily
    {
        public static string GenerateMessage(DateConfigurations configurations, DateTimeOffset date, DateTimeOffset referenceDate)
        {
            var type = configurations.Type;
            var startDate = configurations.Limits.StartDate;

            var message = $"Occurs {type}. Schedule will be used on {referenceDate} starting on {startDate}.";

            return message;
        }
    }
}
