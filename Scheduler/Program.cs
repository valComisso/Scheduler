using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
/*
namespace Scheduler
{
    internal class Program
    {
        private static void Main()
        {
            var now = DateTimeOffset.Now;

            var settings = new DateSettings(
                new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 15, 0, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.Zero)
                );
           

            var dateService = new DateService(new DateValidator());
            var nextDate = dateService.GenerateNextDate(settings);

            if (nextDate?.NextDate == null) return;
            foreach (var date in nextDate.NextDate!)
            {
                System.Console.WriteLine($"The next date is: {date}");
            }
        }
    }
}
*/

public class Program
{
    public static void Main()
    {

        var currentDate = new DateTimeOffset(2024, 7, 16, 0, 0, 0, TimeSpan.Zero); // fecha del dia
        var startDate = new DateTimeOffset(2024, 7, 14, 13, 0, 0, TimeSpan.Zero); // inicio de reango permitido
        var endDate = new DateTimeOffset(2024, 8, 14, 13, 0, 0, TimeSpan.Zero); // fin de rango permitido 
        var dateTimeSettings = new DateTimeOffset(2024, 7, 17, 13, 0, 0, TimeSpan.Zero); // fecha de inicio por configuracion 
        List<DayOfWeek>? selectedDays = new List<DayOfWeek>   // lista de dias permitidos
        {
            DayOfWeek.Monday,
            DayOfWeek.Wednesday,
        };
        var startTime = new TimeSpan(14, 0, 0); // inicio de rango de tiempo permitido
        var endTime = new TimeSpan(16, 0, 0); // fin de rango de tiempo permitido
        var occurrence = OccurrenceType.Weekly; // modalidad de ocurrencia , puede ser recurrente o diaria
        var dailyFrecuency = DailyFrecuencyType.Variable; // frecuencia diaria , puede ser fija o  variable
        var dailyFrecuencyOnceTime = new TimeSpan(15, 0, 0); // horario fijo de todos los dias
        var dailyFrecuencyEvery = new TimeSpan(2, 0, 0); // frecuancia de (horas, min o seg) para cuando el horario no es fijo y hay una franja horaria 

        //DateTimeOffset currentDate,
        //bool statusAvailableType,
        //    EventType? type,
        //OccurrenceType occurrence,
        //uint? every,
        //    DateTimeOffset startDate,
        //DateTimeOffset? dateTimeSettings,
        //    DateTimeOffset? endDate = null

        var settings = new DateSettings(
            currentDate,
            true,
            EventType.Recurring,
            OccurrenceType.Weekly,
            2,
            startDate,
            dateTimeSettings,
            endDate
        )
        {
            WeeklySettingsSelectedDays = selectedDays,
            DailyFrequencyType = dailyFrecuency,
            DailyFrequencyStartTime = startTime,
            DailyFrequencyEndTime = endTime,
            DailyFrequencyEvery = dailyFrecuencyEvery,
            DailyFrequencyFixedTime = dailyFrecuencyOnceTime
        };

        var limit = 15;


        var dateService = new DateService(new DateValidator());
        var result = dateService.GenerateNextDate(settings);


        Console.WriteLine("Próximas fechas disponibles:");
        foreach (var date in result.NextDate)
        {
            Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm"));
        }
    }
}



