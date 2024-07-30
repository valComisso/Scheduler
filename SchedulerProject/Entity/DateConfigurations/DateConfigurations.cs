using SchedulerProject.Enums;

namespace SchedulerProject.Entity.DateConfigurations
{
    public class DateConfigurations(DateTimeOffset currentDate)
    {
        // Main configurations
        public DateTimeOffset CurrentDate { get; } = currentDate;
        public bool StatusAvailableType { get; set; } = true;
        public EventType Type { get; set; } = EventType.Once;
        public OccurrenceType Occurrence { get; set; } = OccurrenceType.Daily;
        public DateTimeOffset? DateTimeSettings { get; set; }

        public uint? Every { get; set; } = 1;

        // limits
        public LimitsConfigurations Limits { get; set; } = new LimitsConfigurations();

        // Daily Frequency Configurations
        public DailyFrequencyConfigurations? FrequencyConfigurations { get; set; }

        // Weekly Configurations
        public WeeklyConfigurations WeeklyConfigurations { get; set; } = new WeeklyConfigurations();


    }
}