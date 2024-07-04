using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Scheduler.Clases
{
    public partial class Dashboard
    {
         //funcion que calulara devolvera la proxima fecha

        public Dashboard() {
         //aca deberia inciar el componente date
        }

        public void generateNextDate (DateTime date) {

            /*
            Parametros:

             CurrentDate - DateTime - OBLIGATORIO

             statusAvailableType  - Bool - obligatorio - Predefinido por configuraciones por defecto
             type        - String - obligatorio - Cuenta con un valor por defecto en las configuraciones por defecto 
             DateTimeSettings     - DateTime - opcional 
             Occurs      - String - obligatorio - definifa por configuraciones por defecto, hasta el momento su unico valor es "Daily" y no se en que influye 
             Every       - Int - obligatorio - Cuenta por un valor por defecto de 0 en la configuraciones por defecto

             StartDate   - DateTime - obligatorio
             EndDate     - DateTime - opcional 

             Pasos a seguir 
             1. verifico contar con CurrentDate y que tenga un formato correcto  con el metodo "validateFormatDate"
             2. Verifico y reuno todas la "Configuraciones" que son necesarias 
                - si statusAvailableType es false entonces  type = "Once"
                  si statusAvailableType es True y cuento con el valor de type entonces type = valorDeType
                  si no cuento con el valor de type , type = "once" por defecto.
                - si type es igual a "once" entonces Verificar si cuento con DateTimeSettings, de ser asi verificar si tiene el formato correcto con el metodo "validateFormatDate" y verificar que DateTimeSettings > currentDate 
                - Defino Every , si viene el valor verifico que sea un entero y lo utilizo, de no venir lo igualo a cero
             3. Verifico con que variables cuento en la seccion Limits
                - Si cuento con StartDate , verifico que sea un formato de fecha adecuado con  "validateFormatDate" 
                - si cuento con EndDate, verifico que sea del formato de fecha adecuado con "validateFormatDate"
                - se debe cumplir que EndDate > StartDate para que sean limites validos 
                - Luego de eso reviso si mi fecha de partida entra en ese rango 
                - si cuento con DateTimeSettings verifico que este en el rango permitido con el metodo "DateRangeValidator"
                - si no cuento con DateTimeSettings verifico que CurrentDate este dentro del rango permitido con el metodo "DateRangeValidator"

            */
        }

        /*
         CLASES GENERALES NECESARIAS
         - ValidateCurrentDate = valide todo lo que tenga que ver con el valor de entrada del input inicial.
           Recibira como parametro:
           * currentDate - obligatorio
         - ValidateConfigurations = Que devuelva un objeto de configuraciones establecidas y verificadas; Debera tener acceso a un archivo de configuraciones por defecto que guarde y donde se pueda definir el valor de los parametros obcionales.
           Recibira como parametro:
           * currentDate - obligatorio
           * type - opcional
           * DateTime - opcional
           * Every - opcional 
         - ValidateLimits = que verifique todo lo que tenga que ver con los limites e indique que todo anda correctamente.
           Recibira como parametro:
           * currentDate - obligatorio
           * StartDate - opcional 
           * EndDate - opcional 
        */

        /*
         METODOS ESPECIFICOS NECESARIOS
         - validateFormatDate : valida que el formato de la fecha pasada sea el correcto. 
           Recibira como parametro:
           * Date
         - DateRangeValidator : valida que una fecha este entre el rango permitido.
           Recibira como parametro:
           * Date - obligatorio 
           * minDate - opcional
           * maxDate - opcional
        */


        private bool ValidateCurrentDate(DateTime date) {

             //por el momento no hay reglas, y no se si son validas fechas posteriores, la actual o futuras

             //verifico si la fecha cuenta con el formato correcto con validateFormatDate; (en este momento supongo que si)

             //verifico que la fecha este dentro de los rangos establecidos como limites; utilizo el metodo DateRangeValidator

            return true;
        }

         //METODOS

        private DateTime validateFormatDate(DateTime date)
        {
             //voy a suponer que ya cuento con un time valido , en el futuro dependera de como se construya la interfas de usuario
            return date;
        }


        private bool DateRangeValidator(DateTime date, DateTime minDate , DateTime maxDate) {
             /*
            debo crear un metodo que valide si una fecha detereminada este dentro de un rango  determinado.
            debo tener en cuenta que la fecha maxima y la fecha minima no son parametros obligatorios, pero de venir acegurarme que se incluyan como valores validos. 
            
            */

            return true;
        }
     


    }
}
