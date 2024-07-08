using SchedulerClassLibrary.Enums;

namespace SchedulerClassLibrary.Entity
{
    public class DateSettings
    {
        public DateTimeOffset CurrentDate { get; set; }
        public bool StatusAvailableType { get; set; }
        public EventType Type { get; set; }
        public OccurrenceType Occurrence { get; set; }
        public DateTimeOffset? DateTimeSettings { get; set; }
        public int Every { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }
}
