
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
using SchedulerClassLibrary.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Scheduler
{
    internal class Program
    {
        private static void Main()
        {
            var now = DateTimeOffset.Now;

            var settings = new DateSettings(
                GenerateDateTimeOffset.Generate(2023, 07, 07),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                GenerateDateTimeOffset.Generate(2023, 07, 15),
                GenerateDateTimeOffset.Generate(2023, 07, 10)
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
