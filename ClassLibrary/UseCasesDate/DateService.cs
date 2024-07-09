using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Interfaces;

namespace SchedulerClassLibrary.UseCasesDate
{
    public class DateService
    {
        private static IDateValidator dateValidator;

        public DateService(IDateValidator dateValidator)
        {
            DateService.dateValidator = dateValidator;
        }

        public DateTimeOffset? GenerateNextDate(DateSettings settings)
        {
            ValidateSettings(settings);

            var referenceDate = GetReferenceDate(settings);

            if (!dateValidator.DateRangeValidator(referenceDate, settings.StartDate, settings.EndDate))
            {
                throw new ArgumentException("The reference date is not within the allowed range.");
            }

            return referenceDate < settings.StartDate ? settings.StartDate.AddDays(1) : referenceDate;
        }

        private static void ValidateSettings(DateSettings settings)
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
