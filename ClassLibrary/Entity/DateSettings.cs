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
        public DateTimeOffset CurrentDate { get; set; } = currentDate;
        public bool StatusAvailableType { get; set; } = statusAvailableType;
        public EventType Type { get; set; } = type ?? EventType.Once ;
        public OccurrenceType Occurrence { get; set; } = occurrence;
        public DateTimeOffset? DateTimeSettings { get; set; } = dateTimeSettings;
        public uint Every { get; set; } = every;
        public DateTimeOffset StartDate { get; set; } = startDate;
        public DateTimeOffset? EndDate { get; set; } = endDate;
    }
}
