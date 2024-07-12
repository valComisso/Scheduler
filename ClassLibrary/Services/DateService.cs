using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Interfaces;
using System;
using System.Collections.Generic;

namespace SchedulerClassLibrary.Services
{
    public class DateService(IDateValidator dateValidator)
    {
        public NextDateResult? GenerateNextDate(DateSettings settings)
        {
            if (!settings.StatusAvailableType)
            {
                return new NextDateResult("It is not possible to calculate the next day", null);
            }

            
            ValidateSettings(settings);
            
            var referenceDate = GetReferenceDate(settings);

            if (!dateValidator.DateRangeValidator(referenceDate, settings.StartDate, settings.EndDate))
            {
                throw new ArgumentException("The reference date is not within the allowed range.");
            }

            //ValidateSettings(settings);

            if (settings.Type == EventType.Recurring)
            {
                return GenerateRecurrentDates(settings, referenceDate);
            }

            var nextDate = referenceDate < settings.StartDate ? settings.StartDate : referenceDate;
            var message = $"Occurs {settings.Type}. Schedule will be used on {nextDate} starting on {settings.StartDate}.";

            return new NextDateResult(message, [nextDate]);
        }


        private NextDateResult GenerateRecurrentDates(DateSettings settings, DateTimeOffset referenceDate)
        {
           
            var dates = new List<DateTimeOffset>();
            var currentDate = referenceDate < settings.StartDate ? settings.StartDate : referenceDate;

            for (var i = 0; i < 5; i++)
            {
                if (settings.EndDate.HasValue && currentDate > settings.EndDate.Value)
                {
                    break;
                }

                dates.Add(currentDate);
                currentDate = GetNextDate(currentDate, settings.Occurrence, settings.Every);
            }

            var message = $"Occurs {settings.Type} starting on {settings.StartDate}. Next dates: {string.Join(", ", dates)}";

            return new NextDateResult(message, dates);
        }

        private static DateTimeOffset GetNextDate(DateTimeOffset currentDate, OccurrenceType occurrence, uint every)
        {
            return occurrence switch
            {
                OccurrenceType.Daily => currentDate.AddDays(every),
                OccurrenceType.Weekly => currentDate.AddDays(7), // Here I don't take into account the Every, because I can't imagine how I would work
                OccurrenceType.Monthly => currentDate.AddMonths(1), // Here I don't take into account the Every, because I can't imagine how I would work
                _ => throw new ArgumentException("Invalid occurrence type."),
            };
        }

        private void ValidateSettings(DateSettings settings)
        {
            if (settings.Type == EventType.Once && settings.DateTimeSettings.HasValue)
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
    }
}
