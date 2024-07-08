namespace SchedulerClassLibrary
{

    public class DateSettings
    {
        public DateTimeOffset CurrentDate { get; set; }
        public bool StatusAvailableType { get; set; }
        public enum EventType
        {
            Once,
            Recurring
        }
        public EventType Type { get; set; }
        public enum OccurrenceType
        {
            Daily,
            Weekly,
            Monthly
        }
        public OccurrenceType Occurrence { get; set; }
        public DateTimeOffset? DateTimeSettings { get; set; }
        public int Every { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }

}
