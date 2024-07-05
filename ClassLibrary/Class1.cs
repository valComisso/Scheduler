using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Library
{
    public class DateSettings
    {
        public string CurrentDate { get; set; }
        public bool StatusAvailableType { get; set; }
        public string Type { get; set; }
        public string Occurs { get; set; }
        public object DateTimeSettings { get; set; }
        public int? Every { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class DateValidationResult 
    {
        // representa a una respuesta de validacion de una fecha 
        public bool IsValid { get; set; }
        public DateTime? Value { get; set; }
    }



    public static class DateValidator
    {

        public static bool ValidateFormatDate(string dateString)
        {
            return DateTime.TryParse(dateString, out _);
        }
       
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
            /*
            if (value is DateTime) { 
                return (DateTime)value;
            }

            else if (value is string)
            {
                if (DateTime.TryParse((string)value, out DateTime result))
                {
                    return result;
                }
            }
            else
            {
                    DateTime dt = Convert.ToDateTime(value);
                    return dt;
            }

            return (DateTime)value;
            */

            return value switch
            {
                DateTime dateTimeValue => dateTimeValue,
                string stringValue when DateTime.TryParse(stringValue, out var result) => result,
                _ => Convert.ToDateTime(value)
            };
        }

        public static DateValidationResult GetValidDate(object value)
        {
            /*
            var result = new DateValidationResult();

            if (ValidateTypeDateTime(value))
            {
                result.IsValid = true;
                result.Value = ConvertToDateTime(value);
            }
            else
            {
                result.IsValid = false;
                result.Value = null;
            }

            return result;
            */

            return new DateValidationResult
            {
                IsValid = ValidateTypeDateTime(value),
                Value = ValidateTypeDateTime(value) ? ConvertToDateTime(value) : (DateTime?)null
            };
        }

    }


}
