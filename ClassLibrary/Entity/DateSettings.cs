using SchedulerClassLibrary.Enums;

namespace SchedulerClassLibrary.Entity
{
    public class DateSettings(
        DateTimeOffset currentDate,
        bool statusAvailableType,
        EventType? type,
        OccurrenceType occurrence,
        uint? every,
        DateTimeOffset startDate,
        DateTimeOffset? dateTimeSettings,
        DateTimeOffset? endDate = null
            )
    {
        // Main configurations
        public DateTimeOffset CurrentDate { get; } = currentDate;
        public bool StatusAvailableType { get;  } = statusAvailableType;
        public EventType Type { get;  } = type ?? EventType.Once ;
        public OccurrenceType Occurrence { get;  } = occurrence;
        public DateTimeOffset? DateTimeSettings { get;  } = dateTimeSettings;
        public DateTimeOffset StartDate { get; } = startDate;
        public DateTimeOffset? EndDate { get; } = endDate;

        // Daily Frecuency Configurations
        public DailyFrecuencyType? DailyFrequencyType { get; set; }
        public TimeSpan? DailyFrequencyFixedTime { get; set; }
        public TimeSpan? DailyFrequencyStartTime { get; set; } 
        public TimeSpan? DailyFrequencyEndTime { get; set; } 
        public TimeSpan? DailyFrequencyEvery { get; set; }

        // Weekly Configurations
        public List<DayOfWeek>? WeeklySettingsSelectedDays { get; set; }
        public uint? Every { get; } = every;

    }
}
