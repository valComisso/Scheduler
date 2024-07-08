
namespace SchedulerClassLibrary
{
    public class DateService
    {

        
        public DateTimeOffset? GenerateNextDate(DateSettings settings)
        {

            var currentDate = settings.CurrentDate;

            var type = settings.StatusAvailableType ? settings.Type :  DateSettings.EventType.Once;
            
            var dateTimeSettings = settings.DateTimeSettings;

            var startDate = settings.StartDate;

            DateTimeOffset? endDate = settings.EndDate;


            if (type == 0 && dateTimeSettings != null)
            {
                if (dateTimeSettings < currentDate)
                {
                    throw new ArgumentException("DateTimeSettings debe ser mayor que CurrentDate.");
                }


                if (!DateValidator.DateRangeValidator(dateTimeSettings, startDate, endDate))
                {
                    throw new ArgumentException("La fecha de DateTime de las configuraciones no está dentro del rango permitido.");
                }
            }


            if ((endDate != null) && (endDate <= startDate))
            {
                throw new ArgumentException("EndDate debe ser mayor que StartDate.");
            }


            //var every = settings.Every ?? 0;
            //var momentThatOccurs = settings.Occurs;

            var referenceDate = dateTimeSettings > currentDate? dateTimeSettings : currentDate.AddDays(1);

          
                if (!DateValidator.DateRangeValidator(referenceDate, startDate, endDate ))
                {
                    throw new ArgumentException("La fecha de referencia no está dentro del rango permitido.");
                }
          

            var result = referenceDate < startDate ? startDate.AddDays(1) : referenceDate;


            
            return result;
        }
    }
}
