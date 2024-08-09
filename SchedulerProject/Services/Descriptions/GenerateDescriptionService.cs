using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Entity.Results;
using SchedulerProject.Enums;

namespace SchedulerProject.Services.Descriptions
{
    public static class GenerateDescriptionService
    {
        public static List<DateResult> AddMessages(List<DateTimeOffset> dates, DateTimeOffset referenceDate, DateConfigurations configurations)
        {
            var type = configurations.Type;
            var startDate = configurations.Limits.StartDate;

            var message = configurations.Type switch
            {
                EventType.Recurring => GenerateDescriptionRecurring.GenerateMessage(configurations, startDate),
                EventType.Once => GenerateDescriptionDaily.GenerateMessage(configurations, startDate, referenceDate)
            };

            return dates.Select(date => new DateResult(message, date)).ToList();
        }

    }
}
