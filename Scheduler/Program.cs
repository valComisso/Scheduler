
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
