﻿using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;

namespace SchedulerProject.UtilsDate
{
    public static class IntervalCalculator
    {
        public static DateTimeOffset GetNextIntervalStart(DateTimeOffset currentDate, DateConfigurations configurations)
        {
            var every = configurations.Every ?? 1;
            var occurrence = configurations.Occurrence;

            DateTimeOffset nextDate = currentDate;

            switch (occurrence)
            {
                case OccurrenceType.Daily:
                    nextDate = GetNextDailyInterval(currentDate, every);
                    break;
                case OccurrenceType.Weekly:
                    nextDate = GetNextWeeklyInterval(currentDate, every);
                    break;

            }

            return TimeDate.ResetTimeDate(nextDate);
        }

        private static DateTimeOffset GetNextDailyInterval(DateTimeOffset currentDate, uint every)
        {
            return currentDate.AddDays(every);
        }

        private static DateTimeOffset GetNextWeeklyInterval(DateTimeOffset currentDate, uint every)
        {
            var daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek + 7) % 7;
            var daysUntilStartNextInterval = 7 * (int)(every - 1);
            var totalDaysToAdd = daysUntilNextMonday + daysUntilStartNextInterval;

            return currentDate.AddDays(totalDaysToAdd);
        }

    }
}
