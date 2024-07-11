using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Interfaces;

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

            var nextDate = referenceDate < settings.StartDate ? settings.StartDate.AddDays(1) : referenceDate;
            var message = $"occurs {settings.Type}. Schedule will be used on {nextDate} starting on {settings.StartDate}.";

            return new NextDateResult(message, nextDate);
        }

        private void ValidateSettings(DateSettings settings)
        {
          
            if (settings is { Type: 0, DateTimeSettings: not null })
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

            if (settings.EndDate != null && settings.EndDate <= settings.StartDate)
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
