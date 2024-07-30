﻿using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services
{
    public class RecurringDatesService
    {
        public static List<DateTimeOffset> GetNextAvailableDates(DateConfigurations configurations, DateTimeOffset startDate, int? limitOccurrences = null)
        {
            var availableDates = new List<DateTimeOffset>();
            var referenceDate = startDate;
            var count = 0;
            var limit = limitOccurrences ?? int.MaxValue;
            var requiredDaysList = SetAllowedDays.DefineAllowedDaysOfTheWeek(configurations.WeeklyConfigurations.SelectedDays);
            var weeksIntervalInt = configurations.Every ?? 1;
            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;

            while (count < limit && referenceDate <= endDate)
            {
                referenceDate = ProcessInterval(referenceDate, requiredDaysList, ref count, availableDates, limit, configurations);
                referenceDate = IntervalCalculator.GetNextIntervalStart(referenceDate, configurations.Occurrence, weeksIntervalInt);
            }

            return availableDates;
        }

        private static DateTimeOffset ProcessInterval(
            DateTimeOffset referenceDate,
            List<DayOfWeek> requiredDaysList,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DateConfigurations configurations
        )
        {
            var daysProcess = GetDaysToProcess(referenceDate, configurations.Occurrence);
            var endOfProcess = referenceDate.AddDays(daysProcess);

            for (var date = referenceDate; date <= endOfProcess; date = TimeDate.ResetTimeDate(date).AddDays(1))
            {
                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddAvailableTimesForDay(date, ref count, availableDates, limit, configurations, referenceDate);
            }

            return endOfProcess;
        }

        private static int GetDaysToProcess(DateTimeOffset referenceDate, OccurrenceType occurrence)
        {
            return occurrence switch
            {
                OccurrenceType.Daily => 0,
                OccurrenceType.Weekly => 7 - (int)referenceDate.DayOfWeek,
                _ => 0
            };
        }

        private static void AddAvailableTimesForDay(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DateConfigurations configurations,
            DateTimeOffset referenceDate
        )
        {
            var dailyFrequencyConf = configurations.FrequencyConfigurations;
            if (dailyFrequencyConf == null) return;

            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;

            if (dailyFrequencyConf.Type == DailyFrequencyType.Fixed)
            {
                AddTimesToDatesService.AddFixedTime(date, ref count, availableDates, limit, dailyFrequencyConf, endDate);
            }
            else if (dailyFrequencyConf.Type == DailyFrequencyType.Variable)
            {
                AddTimesToDatesService.AddVariableTimes(date, ref count, availableDates, limit, dailyFrequencyConf, endDate, referenceDate);
            }
        }

    }
}
