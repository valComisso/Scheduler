
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.UseCasesDate;

namespace Scheduler
{
    internal class Program
    {
        private static void Main()
        {
            var now = DateTimeOffset.Now;

            var settings = new DateSettings
            {
                CurrentDate = now,
                StatusAvailableType = true,
                Type = 0,
                Occurrence = 0,
                DateTimeSettings = now,
                Every = 1,
                StartDate =now,
                EndDate = null,
            };

            var dateService = new DateService(new DateValidator());
            var nextDate = dateService.GenerateNextDate(settings);

            System.Console.WriteLine($"The next date is: {nextDate.ToString()}");
        }
    }
}
