using SchedulerProject.Enums;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class DailyFrequencyConfigurations
    {
        public DailyFrequencyType? Type { get; set; }
        public TimeSpan? FixedTime { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public TimeSpan? Every { get; set; }
    }
}