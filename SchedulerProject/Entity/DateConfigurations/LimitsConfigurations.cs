namespace SchedulerProject.Entity.DateConfigurations
{
    public class LimitsConfigurations
    {
        public DateTimeOffset StartDate { get;}
        public DateTimeOffset? EndDate { get;}

        public LimitsConfigurations(DateTimeOffset startDate, DateTimeOffset? endDate = null)
        {
            if (endDate.HasValue && startDate > endDate.Value)
            {
                throw new ArgumentException("startDate cannot be greater than endDate.");
            }

            StartDate = startDate;
            EndDate = endDate;
        }

        public LimitsConfigurations() : this(DateTimeOffset.Now, null)
        {
        }
    }
}