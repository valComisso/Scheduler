using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;

namespace SchedulerProject.UtilsDate
{
    internal class GetAvailableWeeksOfTheMonth
    {


        public static LimitsConfigurations GetWeek(MonthlyFrequency frequency, DateTimeOffset date)
        {

            var firstDayMonth = new DateTime(date.Year, date.Month, 1);

            var firstMondayIdentifier = firstDayMonth.DayOfWeek == DayOfWeek.Sunday ? 1 : 8 - (int)firstDayMonth.DayOfWeek;
            var firstMonday = firstDayMonth.AddDays(firstMondayIdentifier);

            var startWeek = frequency switch
            {
                MonthlyFrequency.First => firstDayMonth,
                MonthlyFrequency.Second => firstMonday.AddDays(7),
                MonthlyFrequency.Third => firstMonday.AddDays(14),
                MonthlyFrequency.Fourth => firstMonday.AddDays(21),
                MonthlyFrequency.Last => CalculateLastWeek(firstMonday, date),
                _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, null)
            };

            var endWeek = startWeek.AddDays(6);

            if (endWeek.Month != date.Month)
            {
                endWeek = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            }

            return new LimitsConfigurations(startWeek, endWeek);

        }

        private static DateTime CalculateLastWeek(DateTime firstMonday, DateTimeOffset referenceDate)
        {
            var lastDayOfMonth = new DateTime(referenceDate.Year, referenceDate.Month, DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month));

            var daysToMonday = (int)lastDayOfMonth.DayOfWeek - (int)firstMonday.DayOfWeek;
            if (daysToMonday < 0)
            {
                daysToMonday += 7;
            }

            var lastMonday = lastDayOfMonth.AddDays(-daysToMonday);

            return lastMonday;
        }

    }
}

