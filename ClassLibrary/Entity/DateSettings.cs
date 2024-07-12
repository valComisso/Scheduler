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
        DateTimeOffset? endDate = null
        )
    {
        public DateTimeOffset CurrentDate { get; } = currentDate;
        public bool StatusAvailableType { get;  } = statusAvailableType;
        public EventType Type { get;  } = type ?? EventType.Once ;
        public OccurrenceType Occurrence { get;  } = occurrence;
        public DateTimeOffset? DateTimeSettings { get;  } = dateTimeSettings;
        public uint Every { get; } = every;
        public DateTimeOffset StartDate { get; } = startDate;
        public DateTimeOffset? EndDate { get; } = endDate;
    }
}
