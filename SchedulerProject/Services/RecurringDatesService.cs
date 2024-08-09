using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services
{
    public static class RecurringDatesService
    {
        public static List<DateTimeOffset> GetNextAvailableDates(DateConfigurations configurations, DateTimeOffset startDate, int? limitOccurrences = null)
        {
            var availableDates = new List<DateTimeOffset>();
            var referenceDate = startDate;
            var count = 0;
            var limit = limitOccurrences ?? int.MaxValue;
            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;

            while (count < limit && referenceDate <= endDate)
            {
                referenceDate = ProcessInterval(referenceDate, ref count, availableDates, configurations);
                referenceDate = IntervalCalculator.GetNextIntervalStart(referenceDate, configurations);
            }

            return availableDates;
        }

        private static DateTimeOffset ProcessInterval(
            DateTimeOffset referenceDate,
            ref int count,
            List<DateTimeOffset> availableDates,
            DateConfigurations configurations
        )
        {
            var daysProcess = GetDaysToProcess(referenceDate, configurations.Occurrence);
            var endOfProcess = referenceDate.AddDays(daysProcess);

            switch (configurations.Occurrence)
            {
                case OccurrenceType.Daily:
                    ProcessIntervalDaily(ref count, availableDates, configurations, referenceDate, endOfProcess);
                    break;
                case OccurrenceType.Weekly:
                    ProcessIntervalWeekly(ref count, availableDates, configurations, referenceDate, endOfProcess);
                    break;
                case OccurrenceType.Monthly:
                    ProcessIntervalMonthly(ref count, availableDates, configurations, referenceDate, endOfProcess);
                    break;
            }
            return endOfProcess;
        }

        private static void ProcessIntervalDaily(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations, DateTimeOffset referenceDate, DateTimeOffset endOfProcess)
        {
            for (var date = referenceDate; date <= endOfProcess; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                AddAvailableTimesForDay(date, ref count, availableDates, configurations);
            }
        }

        private static void ProcessIntervalWeekly(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations, DateTimeOffset referenceDate, DateTimeOffset endOfProcess)
        {
            for (var date = referenceDate; date <= endOfProcess; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                var requiredDaysList = SetAllowedDays.DefineAllowedDaysOfTheWeek(configurations.WeeklyConfigurations.SelectedDays);

                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddAvailableTimesForDay(date, ref count, availableDates, configurations);
            }
        }

        private static void ProcessIntervalMonthly(ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations, DateTimeOffset referenceDate, DateTimeOffset endOfProcess)
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
                AddAvailableTimesForDay(dateRequired, ref count, availableDates, configurations);
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
                AddAvailableTimesForDay(referenceDate, ref count, availableDates, configurations);
            }
        }

        private static void ProcessDayTypeFrequency(DayType dayType, MonthlyFrequency frequency, DateTimeOffset referenceDate, ref int count, List<DateTimeOffset> availableDates, DateConfigurations configurations)
        {
            var requiredDaysList = GetRequiredDaysList(dayType);

            var limits = GetAvailableWeeksOfTheMonth.GetWeek(frequency, referenceDate);
            if (!DateValidator.DateRangeValidator(referenceDate, limits)) return;

            for (var date = referenceDate; date <= limits.EndDate; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddAvailableTimesForDay(date, ref count, availableDates, configurations);
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

        private static int GetDaysToProcess(DateTimeOffset referenceDate, OccurrenceType occurrence)
        {
            return occurrence switch
            {
                OccurrenceType.Daily => 0,
                OccurrenceType.Weekly => 7 - (int)referenceDate.DayOfWeek,
                OccurrenceType.Monthly => DateTime.DaysInMonth(referenceDate.Year, referenceDate.Month) - (int)referenceDate.Day,
                _ => 0
            };
        }

        private static void AddAvailableTimesForDay(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            DateConfigurations configurations
        )
        {
            var dailyFrequencyConf = configurations.FrequencyConfigurations;
            if (dailyFrequencyConf == null) return;

            if (dailyFrequencyConf.Type == DailyFrequencyType.Fixed)
            {
                AddTimesToDatesService.AddFixedTime(date, ref count, availableDates, configurations);
            }
            else if (dailyFrequencyConf.Type == DailyFrequencyType.Variable)
            {
                AddTimesToDatesService.AddVariableTimes(date, ref count, availableDates, configurations);
            }
        }

    }
}
