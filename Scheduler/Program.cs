using System;
using Scheduler.Library;

namespace Scheduler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            var settings = new DateSettings
            {
                CurrentDate = now.ToLongDateString(),
                StatusAvailableType = true,
                //Type = "Recurring",
                DateTimeSettings = DateTime.Now.AddDays(2),
                Every = 1,
                StartDate = now.ToString(),
                EndDate = now.AddDays(10).ToString(),
            };

            var dateService = new DateService();
            var nextDate = dateService.GenerateNextDate(settings);

            System.Console.WriteLine($"La siguiente fecha es: {nextDate.ToShortDateString()}");
        }
    }
}
