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

            if (settings.Type != EventType.Recurring) return SendResults([nextDate], nextDate, settings);

            var nextDates = RecurringDateService.GetNextAvailableDates(settings, nextDate, limitOccurrences);

            return SendResults(nextDates, nextDate, settings);
        }

        private static NextDateResult SendResults(List<DateTimeOffset> dates, DateTimeOffset nextDate, DateSettings settings)
        {
            var message = settings.Type switch
            {
                EventType.Recurring => $"Occurs {settings.Type}. Starting on {settings.StartDate}.",
                EventType.Once =>
                    $"Occurs {settings.Type}. Schedule will be used on {nextDate} starting on {settings.StartDate}.",
                _ => ""
            };

            return new NextDateResult(message, dates);
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

            if (settings.Every is null or 0)
            {
                throw new ArgumentException(" Every must be counted on");
            }
            if (settings is { Occurrence: OccurrenceType.Weekly, WeeklySettingsSelectedDays: null })
            {
                throw new ArgumentException("the days allowed must be counted");
            }

            switch (settings.DailyFrequencyType)
            {
                case DailyFrecuencyType.Fixed when settings.DailyFrequencyFixedTime == null:
                    throw new ArgumentException("The fixed time for each date must be defined");
                case DailyFrecuencyType.Variable when settings.DailyFrequencyStartTime == null || settings.DailyFrequencyEndTime == null || settings.DailyFrequencyEvery == null:
                    throw new ArgumentException("Invalid parameters for setting schedules by date");
                case null:
                    throw new ArgumentException("A frequency type must be defined for the generation of the next dates");
            }

        }

        private static DateTimeOffset GetReferenceDate(DateSettings settings)
        {
            var type = settings.Type;
            var currentDate = settings.CurrentDate;
            var dateTimeSettings = settings.DateTimeSettings;
            DateTimeOffset referenceDate = type switch
            {
                EventType.Once => dateTimeSettings > currentDate ? dateTimeSettings.Value : currentDate.AddDays(1),
                EventType.Recurring => currentDate,
                _ => default
            };

            return referenceDate;
        }



    }
}
