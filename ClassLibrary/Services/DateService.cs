using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Interfaces;

namespace SchedulerClassLibrary.Services
{
    public class DateService(IDateValidator dateValidator)
    {
        public NextDateResult? GenerateNextDate(DateSettings settings, int? limitOccurrences = null)
        {
            if (!settings.StatusAvailableType)
            {
                return new NextDateResult("It is not possible to calculate the next day", null!);
            }


            ValidateSettings(settings);

            var referenceDate = GetReferenceDate(settings);

            if (!dateValidator.DateRangeValidator(referenceDate, settings.StartDate, settings.EndDate))
            {
                throw new ArgumentException("The reference date is not within the allowed range.");
            }


            var nextDate = referenceDate < settings.StartDate ? settings.StartDate : referenceDate;

            if (settings.Type == EventType.Recurring)
            {
                return GetNextAvailableDates(settings, nextDate, limitOccurrences);
            }

            var message = $"Occurs {settings.Type}. Schedule will be used on {nextDate} starting on {settings.StartDate}.";

            return new NextDateResult(message, [nextDate]);
        }


        private NextDateResult GetNextAvailableDates(DateSettings settings, DateTimeOffset nextDate, int? limitOccurrences)
        {

            var availableDates = new List<DateTimeOffset>();
            var count = 0;
            var currentDate = nextDate;
            var limit = limitOccurrences is null or < 0 ? 5 : limitOccurrences.Value;

            var referenceDate = nextDate;
            var requiredDaysList = GetRequiredDays(settings.WeeklySettingsSelectedDays);
            var weeksIntervalInt = settings.Every ?? 1;

            var endDate = settings.EndDate ?? DateTimeOffset.MaxValue;

            while (count < limit && referenceDate < endDate)
            {
               
                referenceDate = ProcessWeek(referenceDate, requiredDaysList, limit, ref count, availableDates, settings, endDate);
                referenceDate = GetNextReferenceDate(weeksIntervalInt, referenceDate);
            }


            var message = $"Occurs {settings.Type}. Starting on {settings.StartDate}.";

            return new NextDateResult(message, availableDates);
        }


        private static DateTimeOffset ProcessWeek(DateTimeOffset referenceDate, List<DayOfWeek> requiredDaysList, int limit, ref int count, List<DateTimeOffset> availableDates, DateSettings settings, DateTimeOffset endDate)
        {
            var endOfWeek = referenceDate.AddDays(7 - (int)referenceDate.DayOfWeek);

            for (var date = referenceDate; date <= endOfWeek; date = date.AddDays(1))
            {
                if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
                AddAvailableDatesForDay(date, limit, ref count, availableDates, settings, endDate);
            }

            return endOfWeek;
        }

        private static void AddAvailableDatesForDay(DateTimeOffset date, int limit,  ref int count, List<DateTimeOffset> availableDates, DateSettings settings, DateTimeOffset endDate)
        {
            var endTime = settings.DailyFrecuencyEndTime ?? new TimeSpan(23, 59, 59);
            var startTime = settings.DailyFrecuencyStartTime ?? TimeSpan.Zero;
            var interval = settings.DailyFrecuencyEvery ?? new TimeSpan(1, 0, 0);
            var targetDateTime = date.Add(startTime);
            var endTimeDate =  date.Add(endTime);

            while (targetDateTime <= endTimeDate && count < limit && targetDateTime <= endDate)
            {
                if (IsWithinTimeFrame(targetDateTime, startTime, endTime))
                {
                    availableDates.Add(targetDateTime);
                    count++;
                }

                targetDateTime = targetDateTime.Add(interval);
            }
        }

        private static bool IsWithinTimeFrame(DateTimeOffset targetDateTime, TimeSpan startTime, TimeSpan endTime)
        {
            return targetDateTime.TimeOfDay >= startTime && targetDateTime.TimeOfDay <= endTime;
        }
        private static DateTimeOffset GetNextReferenceDate(uint weeksIntervalInt, DateTimeOffset date)
        {
            var daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
            var daysUntilStartNextInterval = 7 * (weeksIntervalInt - 1);
            var totalDaysToAdd = daysUntilNextMonday + daysUntilStartNextInterval;

            var nexDate = date.AddDays(totalDaysToAdd);
            var nextTDateReference = new DateTimeOffset(nexDate.Year, nexDate.Month, nexDate.Day, 0, 0, 0, date.Offset);

            return nextTDateReference;
        }



        private static DateTimeOffset GetNextDate(DateTimeOffset currentDate, OccurrenceType occurrence, uint every)
        {
            return occurrence switch
            {
                OccurrenceType.Daily => currentDate.AddDays(every),
                OccurrenceType.Weekly => currentDate,
                _ => throw new ArgumentException("Invalid occurrence type."),
            };
        }

        private void ValidateSettings(DateSettings settings)
        {
            ValidateMainSettings(settings);

            if (settings.Type == EventType.Recurring)
            {
                ValidateRecurringSettings(settings);
            }

        }

        private void ValidateMainSettings(DateSettings settings)
        {
            if (settings is { Type: EventType.Once, DateTimeSettings: not null })
            {
                if (settings.DateTimeSettings < settings.CurrentDate)
                {
                    throw new ArgumentException("DateTimeSettings must be larger than CurrentDate.");
                }

                if (!dateValidator.DateRangeValidator(settings.DateTimeSettings.Value, settings.StartDate, settings.EndDate))
                {
                    throw new ArgumentException("The DateTime date of the settings is not within the allowed range.");
                }
            }

            if (settings.EndDate.HasValue && settings.EndDate <= settings.StartDate)
            {
                throw new ArgumentException("EndDate must be larger than StartDate.");
            }
        }

        private void ValidateRecurringSettings(DateSettings settings)
        {
            if (settings is { Type: EventType.Once, DateTimeSettings: not null })
            {
                if (settings.DateTimeSettings < settings.CurrentDate)
                {
                    throw new ArgumentException("DateTimeSettings must be larger than CurrentDate.");
                }

                if (!dateValidator.DateRangeValidator(settings.DateTimeSettings.Value, settings.StartDate, settings.EndDate))
                {
                    throw new ArgumentException("The DateTime date of the settings is not within the allowed range.");
                }
            }

            if (settings.EndDate.HasValue && settings.EndDate <= settings.StartDate)
            {
                throw new ArgumentException("EndDate must be larger than StartDate.");
            }
        }
        private static DateTimeOffset GetReferenceDate(DateSettings settings)
        {
            var currentDate = settings.CurrentDate;
            var dateTimeSettings = settings.DateTimeSettings;
            var referenceDate = dateTimeSettings > currentDate ? dateTimeSettings.Value : currentDate.AddDays(1);
            return referenceDate;
        }
        private static List<DayOfWeek> GetRequiredDays(List<DayOfWeek>? days)
        {
            return days ?? new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Tuesday,
                DayOfWeek.Wednesday,
                DayOfWeek.Thursday,
                DayOfWeek.Friday,
                DayOfWeek.Saturday,
                DayOfWeek.Sunday
            };
        }



    }
}
