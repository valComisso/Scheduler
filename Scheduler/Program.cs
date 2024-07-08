using System;
using SchedulerClassLibrary;

namespace Scheduler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var now = DateTimeOffset.Now;

            var settings = new DateSettings
            {
                CurrentDate =now,
                StatusAvailableType = true,
                Type = 0,
                Occurrence = 0,
                DateTimeSettings = now,
                Every = 1,
                StartDate =now,
                EndDate = null,
            };

            var dateService = new DateService();
            var nextDate = dateService.GenerateNextDate(settings);

            System.Console.WriteLine($"La siguiente fecha es: {nextDate.ToString()}");
        }
    }
}
