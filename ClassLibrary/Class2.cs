
namespace Scheduler.Library
{
    public class DateService
    {

        
        public DateTime GenerateNextDate(DateSettings settings)
        {
            DateTime currentDate;

            
            if (!DateValidator.ValidateFormatDate(settings.CurrentDate))
            {
                throw new ArgumentException("CurrentDate tiene un formato incorrecto.");
            }
            else
            {
                currentDate = DateTime.Parse(settings.CurrentDate);
            }

            string type = "Once";
            if (settings.StatusAvailableType)
            {
                type = string.IsNullOrEmpty(settings.Type) ? "Once" : settings.Type;
            }

            DateTime? dateTimeSettings = null;

            if ( !(settings.DateTimeSettings == null))
            {
                DateTime? resultDateValidate = DateValidator.validateDate(settings.DateTimeSettings);

                if (resultDateValidate == null)
                {
                   throw new ArgumentException("DateTimeSettings tiene un formato incorrecto.");
                }
                else {
                    dateTimeSettings = resultDateValidate;
                }

                //if (DateValidator.ValidateTypeDateTime(settings.DateTimeSettings))
                //{
                //    if (settings.DateTimeSettings is DateTime)
                //    {
                //        dateTimeSettings = (DateTime)settings.DateTimeSettings;
                //    }
                //    else
                //    {
                //        dateTimeSettings = DateValidator.ConvetToDateTime(settings.DateTimeSettings);
                //    }
                //}
                //else
                //{
                //    throw new ArgumentException("DateTimeSettings tiene un formato incorrecto.");
                //}
            }


            if (type == "Once" && dateTimeSettings != null)
            {
                if (dateTimeSettings <= currentDate)
                {
                    throw new ArgumentException("DateTimeSettings debe ser mayor que CurrentDate.");
                }
            }

            int every = settings.Every.HasValue ? settings.Every.Value : 0;

            DateTime? startDate = null;

            if (!(settings.StartDate == null))
            {
                if (!DateValidator.ValidateFormatDate(settings.StartDate))
                {
                    throw new ArgumentException("StartDate tiene un formato incorrecto.");
                }
                else
                {
                    startDate = DateTime.Parse(settings.StartDate);
                }
            }
          

            DateTime? endDate = null;

            if (!(settings.EndDate == null))
            {
                if (!DateValidator.ValidateFormatDate(settings.EndDate))
                {
                    throw new ArgumentException("EndDate tiene un formato incorrecto.");
                }
                else
                {
                    endDate = DateTime.Parse(settings.EndDate);
                }

                if (startDate != null && endDate <= startDate)
                {
                    throw new ArgumentException("EndDate debe ser mayor que StartDate.");
                }
            }

            DateTime referenceDate = dateTimeSettings ?? currentDate;

            if (startDate != null && endDate != null)
            {
                if (!DateValidator.DateRangeValidator(referenceDate, startDate.Value, endDate.Value))
                {
                    throw new ArgumentException("La fecha de referencia no está dentro del rango permitido.");
                }
            }

            return referenceDate.AddDays(every);
        }
    }
}
