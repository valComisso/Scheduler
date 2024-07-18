using SchedulerClassLibrary.Enums;

namespace SchedulerClassLibrary.Entity
{
    public class DateSettings(
        DateTimeOffset currentDate,
        bool statusAvailableType,
        EventType? type,
        OccurrenceType occurrence,
        uint every,
        DateTimeOffset startDate,
        DateTimeOffset? dateTimeSettings,
        DateTimeOffset? endDate = null,
        List<DayOfWeek>? selectedDays = null,
        DailyFrecuencyType? dailyFrecuency = null,
        TimeSpan? startTime = null,
        TimeSpan? endTime = null,
        uint? everyTime = null
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
        public DailyFrecuencyType? DailyFrecuencyType { get; } = dailyFrecuency;
        public TimeSpan? DailyFrecuencyStartTime { get; } = startTime;
        public TimeSpan? DailyFrecuencyEndTime { get; } = endTime;
        public uint? DailyFrecuencyEvery { get; } = everyTime;

        // Weekly Configurations
        public List<DayOfWeek>? WeeklySettingsSelectedDays { get; set; } = selectedDays;
        public uint Every { get; } = every;

    }
}
