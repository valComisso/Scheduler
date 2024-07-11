using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Services;

namespace Scheduler
{
    internal class Program
    {
        private static void Main()
        {
            var now = DateTimeOffset.Now;

            var settings = new DateSettings(now, true, 0, 0, now, 1, now, null);
           

            var dateService = new DateService(new DateValidator());
            var nextDate = dateService.GenerateNextDate(settings);

            System.Console.WriteLine($"The next date is: {nextDate?.NextDate}");
        }
    }
}
