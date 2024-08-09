using SchedulerProject.Enums;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class MonthlyConfigurations
    {
        public MonthlyConfigurationsType Type { get; set; }
        public int? Every { get; set; }
        public uint? DayNumber { get; set; }
        public DayType DayType { get; set; }
        public MonthlyFrequency Frequency { get; set; }

    }
}
