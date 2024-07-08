
namespace SchedulerClassLibrary.Interfaces
{
    public interface IDateValidator
    {
        bool DateRangeValidator(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset? endDate);
    }
}
