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
        public object DateTimeSettings { get; set; }
        public int? Every { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }


    public static class DateValidator
    {

        public static DateTime? validateDate( object date)
        {
            DateTime? result = null;

            if (ValidateTypeDateTime(date))
            {
                result = ConvetToDateTime(date);
            }
            return result;
        }


        public static bool ValidateFormatDate(string dateString)
        {
            return DateTime.TryParse(dateString, out _);
        }
       
        public static bool DateRangeValidator(DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        public static bool ValidateTypeDateTime(object valor)
        {
            // Intentar convertir el valor a DateTime usando TryParse o Convert.ToDateTime
            if (valor is DateTime)
            {
                // Si el valor ya es un DateTime, devolver true
                return true;
            }
            else if (valor is string)
            {
                // Si el valor es una cadena, intentar convertirla a DateTime
                if (DateTime.TryParse((string)valor, out DateTime result))
                {
                    return true;
                }
            }
            else
            {
                // Si el valor no es un DateTime ni una cadena, intentar convertirlo usando Convert.ToDateTime
                try
                {
                    DateTime dt = Convert.ToDateTime(valor);
                    return true;
                }
                catch (InvalidCastException)
                {
                    // Si no se puede convertir, devolver false
                    return false;
                }
                catch (FormatException)
                {
                    // Si hay un error de formato en la conversión, devolver false
                    return false;
                }
            }

            // Si no se pudo convertir a DateTime, devolver false
            return false;
        }


        public static DateTime ConvetToDateTime(object value)
        {

            // Intentar convertir el valor a DateTime usando TryParse o Convert.ToDateTime
            if (value is DateTime) { 
                return (DateTime)value; }

            else if (value is string)
            {
                // Si el valor es una cadena, intentar convertirla a DateTime
                if (DateTime.TryParse((string)value, out DateTime result))
                {
                    return result;
                }
            }
            else
            {
                // Si el valor no es un DateTime ni una cadena, intentar convertirlo usando Convert.ToDateTime
                    DateTime dt = Convert.ToDateTime(value);
                    return dt;
            }

            return (DateTime)value;
        }



    }


}
