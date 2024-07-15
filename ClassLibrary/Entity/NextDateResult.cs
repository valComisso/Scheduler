
namespace SchedulerClassLibrary.Entity
{
    public class NextDateResult(string message, List<DateTimeOffset> nextDate)
    {
        public List<DateTimeOffset> NextDate { get; } = nextDate;
        public string Message { get; } = message;
    }
}
