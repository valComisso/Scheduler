using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;

namespace SchedulerClassLibrary.Services
{

    public class RecurringDateService
    {
        public static List<DateTimeOffset> GetNextAvailableDates(DateSettings settings, DateTimeOffset currentDate, int? limitOccurrences = null)
        {
            var availableDates = new List<DateTimeOffset>();
            var referenceDate = currentDate;
            var count = 0;
            var limit = limitOccurrences ?? int.MaxValue;
            var requiredDaysList = GetRequiredDays(settings.WeeklySettingsSelectedDays);
            var weeksIntervalInt = settings.Every ?? 1;
            var endDate = settings.EndDate ?? DateTimeOffset.MaxValue;

            while (count < limit && referenceDate <= endDate)
            {
                referenceDate = ProcessInterval(referenceDate, requiredDaysList, ref count, availableDates, limit, settings);
                referenceDate = GetNextIntervalStart(referenceDate, settings.Occurrence, weeksIntervalInt);
            }

            return availableDates;
        }


        private static DateTimeOffset ProcessInterval(
            DateTimeOffset referenceDate,
            List<DayOfWeek> requiredDaysList,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DateSettings settings
            )
        {
            var daysProcess = settings.Occurrence switch
            {
                OccurrenceType.Daily => 0,
                OccurrenceType.Weekly => 7 - (int)referenceDate.DayOfWeek,
                _ => 0
            };

            var endOfProcess = referenceDate.AddDays(daysProcess);

            for (var date = referenceDate; date <= endOfProcess; date = ResetTimeDate(date).AddDays(1))
            {
                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddAvailableTimesForDay(date, ref count, availableDates, limit, settings);
            }

            return endOfProcess;
        }


        private static void AddAvailableTimesForDay(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DateSettings settings
            )
        {
            var timeFixed = settings.DailyFrequencyFixedTime ?? TimeSpan.Zero;
            var recurrenceType = settings.DailyFrequencyType;
            var endDate = settings.EndDate ?? DateTimeOffset.MaxValue;
            var endTime = settings.DailyFrequencyEndTime ?? TimeSpan.MaxValue;
            var startTime = settings.DailyFrequencyStartTime ?? TimeSpan.MinValue;
            var every = settings.DailyFrequencyEvery ?? TimeSpan.Zero;

            switch (recurrenceType)
            {
                case DailyFrecuencyType.Fixed when date.TimeOfDay < timeFixed:
                    {
                        var targetDateTime = ResetTimeDate(date).Add(timeFixed);

                        if (targetDateTime > settings.EndDate) return;
                        availableDates.Add(targetDateTime);
                        count++;
                        break;
                    }
                case DailyFrecuencyType.Variable when date.TimeOfDay <= endTime:
                    {
                        var targetDateTime = date;
                        var endTimeDate = date.Add(endTime);

                        while (targetDateTime <= endTimeDate && count < limit && targetDateTime <= endDate)
                        {

                            if (IsWithinTimeFrame(targetDateTime, startTime, endTime))
                            {
                                availableDates.Add(targetDateTime);
                                count++;
                            }

                            targetDateTime = targetDateTime.Add(every);
                        }

                        break;
                    }

            }

        }

        private static bool IsWithinTimeFrame(DateTimeOffset targetDateTime, TimeSpan startTime, TimeSpan endTime)
        {
            return targetDateTime.TimeOfDay >= startTime && targetDateTime.TimeOfDay <= endTime;
        }


        private static DateTimeOffset GetNextIntervalStart(DateTimeOffset currentDate, OccurrenceType occurrence, uint every)
        {
            DateTimeOffset nexDate;
            var nextTDateReference = default(DateTimeOffset);

            switch (occurrence)
            {
                case OccurrenceType.Daily:
                    nexDate = currentDate.AddDays(every);
                    nextTDateReference = ResetTimeDate(nexDate);
                    break;
                case OccurrenceType.Weekly:
                    {
                        var daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek + 7) % 7;
                        var daysUntilStartNextInterval = 7 * (every - 1);
                        var totalDaysToAdd = daysUntilNextMonday + daysUntilStartNextInterval;

                        nexDate = currentDate.AddDays(totalDaysToAdd);
                        nextTDateReference = ResetTimeDate(nexDate);
                        break;
                    }
            }

            return nextTDateReference;
        }


        private static List<DayOfWeek> GetRequiredDays(List<DayOfWeek>? days)
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

        private static DateTimeOffset ResetTimeDate(DateTimeOffset date)
        {
            return new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
        }
    }
}
