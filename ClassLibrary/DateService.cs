﻿namespace SchedulerClassLibrary
{
   
    public class DateService(IDateValidator dateValidator)
    {
        public DateTimeOffset? GenerateNextDate(DateSettings settings)
        {
            ValidateSettings(settings);

            var referenceDate = GetReferenceDate(settings);

            if (!dateValidator.DateRangeValidator(referenceDate, settings.StartDate, settings.EndDate))
            {
                throw new ArgumentException("La fecha de referencia no está dentro del rango permitido.");
            }

            return referenceDate < settings.StartDate ? settings.StartDate.AddDays(1) : referenceDate;
        }

        private void ValidateSettings(DateSettings settings)
        {
            if (settings.Type == DateSettings.EventType.Once && settings.DateTimeSettings != null)
            {
                if (settings.DateTimeSettings < settings.CurrentDate)
                {
                    throw new ArgumentException("DateTimeSettings debe ser mayor que CurrentDate.");
                }

                if (!dateValidator.DateRangeValidator(settings.DateTimeSettings.Value, settings.StartDate, settings.EndDate))
                {
                    throw new ArgumentException("La fecha de DateTime de las configuraciones no está dentro del rango permitido.");
                }
            }

            if ((settings.EndDate != null) && (settings.EndDate <= settings.StartDate))
            {
                throw new ArgumentException("EndDate debe ser mayor que StartDate.");
            }
        }

        private DateTimeOffset GetReferenceDate(DateSettings settings)
        {
            var currentDate = settings.CurrentDate;
            var dateTimeSettings = settings.DateTimeSettings;
            var referenceDate = dateTimeSettings > currentDate ? dateTimeSettings.Value : currentDate.AddDays(1);
            return referenceDate;
        }
    }
}
