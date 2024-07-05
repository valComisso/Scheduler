using System;
using Scheduler.Library;

namespace Scheduler.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime now = DateTime.Now;

            //[InlineData("2023-07-01", true, "Recurring", "", "2023-07-03", 1, "2023-07-01", "2023-07-10", "2023-07-04")]

            var settings = new DateSettings
            {
                CurrentDate = "2023-07-01",
                StatusAvailableType = true,
                Type = "Recurring",
                Occurs = "",
                DateTimeSettings = "2023-07-03",
                Every = 1,
                StartDate = "2023-07-01",
                EndDate = "2023-07-10",
            };

            var dateService = new DateService();
            var nextDate = dateService.GenerateNextDate(settings);

            System.Console.WriteLine($"La siguiente fecha es: {nextDate.ToShortDateString()}");
        }
    }
}
