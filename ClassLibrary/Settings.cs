namespace SchedulerClassLibrary
{

    
    public class DateSettings
    {
        public DateTimeOffset CurrentDate { get; set; }
        public bool StatusAvailableType { get; set; }
        public enum EventType
        {
            Once,
            Recurring
        }
        public EventType Type { get; set; }
        public enum OccurrenceType
        {
            Daily,
            Weekly,
            Monthly
        }
        public OccurrenceType Occurrence { get; set; }
        public DateTimeOffset? DateTimeSettings { get; set; }
        public int Every { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
    }


    public class DateValidationResult 
    {
        // representa a una respuesta de validacion de una fecha 
        public bool IsValid { get; set; }
        public DateTime? Value { get; set; }
    }



    public static class DateValidator
    {
       
        public static bool DateRangeValidator(DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        public static bool ValidateTypeDateTime(object value)
        {
            if (value == null) return false;

            return value switch
            {
                DateTime _ => true,
                string stringValue => DateTime.TryParse(stringValue, out _),
                _ => TryConvertToDateTime(value)
            };
        }

        private static bool TryConvertToDateTime(object value)
        {
            try
            {
                Convert.ToDateTime(value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static DateTime ConvertToDateTime(object value)
        {
            return value switch
            {
                DateTime dateTimeValue => dateTimeValue,
                string stringValue when DateTime.TryParse(stringValue, out var result) => result,
                _ => Convert.ToDateTime(value)
            };
        }

        public static DateValidationResult GetValidDate(object value)
        {

            return new DateValidationResult
            {
                IsValid = ValidateTypeDateTime(value),
                Value = ValidateTypeDateTime(value) ? ConvertToDateTime(value) : (DateTime?)null
            };
        }

    }


}
