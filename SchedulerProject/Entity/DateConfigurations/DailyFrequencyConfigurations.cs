using SchedulerProject.Enums;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class DailyFrequencyConfigurations
    {
        public DailyFrequencyType? Type { get; set; }
        public TimeSpan? FixedTime { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? Every { get; set; }
        public EveryType EveryType { get; set; }
    }
}