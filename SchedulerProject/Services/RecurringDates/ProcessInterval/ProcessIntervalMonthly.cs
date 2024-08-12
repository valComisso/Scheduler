using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services.RecurringDates.ProcessInterval
{
    public static class ProcessIntervalMonthly
    {
        public static void ProcessInterval(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations,
            DateTimeOffset referenceDate)
        {
            var monthlyConfig = configurations.MonthlyConfigurations!;
            var type = monthlyConfig.Type;

            if (type == MonthlyConfigurationsType.Day)
            {
                ProcessDayType(monthlyConfig.DayNumber!.Value, referenceDate, ref count, availableDates, configurations);
            }
            else if (type == MonthlyConfigurationsType.The)
            {
                ProcessTheType(monthlyConfig, referenceDate, ref count, availableDates, configurations);
            }
        }

        private static void ProcessDayType(uint day, DateTimeOffset referenceDate, ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations)
        {
            var dateRequired = new DateTimeOffset(referenceDate.Year, referenceDate.Month, (int)day, 0, 0, 0, referenceDate.Offset);

            if (referenceDate < dateRequired)
            {
                AddTimesToDatesService.AddAvailableTimesForDay(dateRequired, ref count, availableDates, configurations);
            }
        }

        private static void ProcessTheType(MonthlyConfigurations monthlyConfig, DateTimeOffset referenceDate, ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations)
        {
            var frequency = monthlyConfig.Frequency;
            var dayType = monthlyConfig.DayType;

            if (dayType == DayType.Day)
            {
                ProcessDayFrequency(frequency, referenceDate, ref count, availableDates, configurations);
            }
            else
            {
                ProcessDayTypeFrequency(dayType, frequency, referenceDate, ref count, availableDates, configurations);
            }
        }

        private static void ProcessDayFrequency(MonthlyFrequency frequency, DateTimeOffset referenceDate, ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations)
        {
            var dayToCheck = frequency == MonthlyFrequency.Last
                ? DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month)
                : (int)frequency + 1;

            if (referenceDate.Day == dayToCheck)
            {
                AddTimesToDatesService.AddAvailableTimesForDay(referenceDate, ref count, availableDates, configurations);
            }
        }

        private static void ProcessDayTypeFrequency(DayType dayType, MonthlyFrequency frequency, DateTimeOffset referenceDate, ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations)
        {
            var requiredDaysList = GetRequiredDaysList(dayType);

            var limits = GetAvailableWeeksOfTheMonth.GetWeek(frequency, referenceDate);
            if (!DateValidator.DateRangeValidator(referenceDate, limits)) return;

            var startDate = referenceDate > limits.StartDate ? referenceDate : limits.StartDate;
            for (var date = startDate; date <= limits.EndDate; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddTimesToDatesService.AddAvailableTimesForDay(date, ref count, availableDates, configurations);
            }
        }

        private static List<DayOfWeek> GetRequiredDaysList(DayType dayType) => dayType switch
        {
            DayType.Weekday =>
            [
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday
            ],
            DayType.WeekendDay =>
            [
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            ],
            _ => [Enum.Parse<DayOfWeek>(dayType.ToString())]
        };

    }
}
