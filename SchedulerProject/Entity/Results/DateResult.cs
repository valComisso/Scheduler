namespace SchedulerProject.Entity.Results
{
    public class DateResult(string message, DateTimeOffset date)
    {
        public DateTimeOffset NextDate { get; } = date;
        public string Message { get; } = message;
    }
}