namespace SchedulerProject.UtilsDate
{
    public static class SetAllowedDays
    {
        public static List<DayOfWeek> DefineAllowedDaysOfTheWeek(List<DayOfWeek>? days)
        {
            return days ??
            [
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            ];
        }
    }
}