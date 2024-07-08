namespace SchedulerClassLibrary
{
    public interface IDateValidator
    {
        bool DateRangeValidator(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset? endDate);
    }

    public class DateValidator : IDateValidator
    {
        public bool DateRangeValidator(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            return (endDate == null || date <= endDate);
        }
    }
}