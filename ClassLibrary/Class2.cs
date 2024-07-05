
namespace Scheduler.Library
{
    public class DateService
    {

        
        public DateTime GenerateNextDate(DateSettings settings)
        {
            DateTime currentDate;

            
            if (!DateValidator.ValidateTypeDateTime(settings.CurrentDate))
            {
                throw new ArgumentException("CurrentDate tiene un formato incorrecto.");
            }
            else
            {
                currentDate = DateValidator.ConvertToDateTime(settings.CurrentDate);
            }

            var type = "Once";
            
            if (settings.StatusAvailableType)
            {
                type = string.IsNullOrEmpty(settings.Type) ? "Once" : settings.Type;
            }

            DateTime? dateTimeSettings = null;

            if ( settings.DateTimeSettings != null)
            {
                var resultValidateDateTimeSettings = DateValidator.GetValidDate(settings.DateTimeSettings);

                if (!resultValidateDateTimeSettings.IsValid )
                {
                   throw new ArgumentException("DateTimeSettings tiene un formato incorrecto.");
                }
                else {
                    dateTimeSettings = resultValidateDateTimeSettings.Value;
                }
            }


            if (type == "Once" && dateTimeSettings != null)
            {
                if (dateTimeSettings <= currentDate)
                {
                    throw new ArgumentException("DateTimeSettings debe ser mayor que CurrentDate.");
                }
            }


            DateTime? startDate = null;


            if (settings.StartDate != null)
            {
                var resultValidateStartDate = DateValidator.GetValidDate(settings.StartDate);

                if (!resultValidateStartDate.IsValid)
                {
                    throw new ArgumentException("StartDate tiene un formato incorrecto.");
                }
                else
                {
                    startDate = resultValidateStartDate.Value;
                }
            }
          

            DateTime? endDate = null;

            if (settings.EndDate != null)
            {
                var resultValidateEndDate = DateValidator.GetValidDate(settings.EndDate);


                if (!resultValidateEndDate.IsValid)
                {
                    throw new ArgumentException("EndDate tiene un formato incorrecto.");
                }
                else
                {
                    endDate = resultValidateEndDate.Value;
                }

                if (startDate != null && endDate <= startDate)
                {
                    throw new ArgumentException("EndDate debe ser mayor que StartDate.");
                }
            }



            //var every = settings.Every ?? 0;
            //var momentThatOccurs = settings.Occurs;

            var referenceDate = dateTimeSettings ?? currentDate;



            if (startDate != null && endDate != null)
            {
                if (!DateValidator.DateRangeValidator(referenceDate, startDate.Value, endDate.Value))
                {
                    throw new ArgumentException("La fecha de referencia no está dentro del rango permitido.");
                }
            }

            var result = dateTimeSettings ?? currentDate.AddDays(1);


            
            return result;
        }
    }
}
