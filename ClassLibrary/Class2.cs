
namespace SchedulerClassLibrary
{
    public class DateService
    {

        
        public DateTime GenerateNextDate(DateSettings settings)
        {
          
            var currentDate = settings.CurrentDate;


            var type = DateSettings.EventType.Once;
            
            if (settings.StatusAvailableType)
            {
                type = settings.Type;
            }


            DateTimeOffset? dateTimeSettings = settings.DateTimeSettings;

            if ( settings.DateTimeSettings != null)
            {

                if (!(settings.DateTimeSettings is DateTimeOffset))
                {
                    throw new ArgumentException("DateTimeSettings tiene un formato incorrecto.");
                }
                else
                {
                    dateTimeSettings = settings.DateTimeSettings;
                }
              
            }


            if (type == 0 && dateTimeSettings != null)
            {
                if (dateTimeSettings <= currentDate)
                {
                    throw new ArgumentException("DateTimeSettings debe ser mayor que CurrentDate.");
                }
            }


            DateTimeOffset? startDate = null;


            if (settings.StartDate != null)
            {
                if (!(settings.StartDate is DateTimeOffset))
                {
                    throw new ArgumentException("StartDate tiene un formato incorrecto.");
                }
                else
                {
                    startDate = settings.StartDate;
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
