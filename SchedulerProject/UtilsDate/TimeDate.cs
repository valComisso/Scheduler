namespace SchedulerProject.UtilsDate
{
    public static class TimeDate
    {
        public static DateTimeOffset ResetTimeDate(DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
        }
    }
}