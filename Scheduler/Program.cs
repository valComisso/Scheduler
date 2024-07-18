using SchedulerClassLibrary.Enums;
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

        var currentDate = new DateTimeOffset(2024, 7, 16, 0, 0, 0, TimeSpan.Zero);
        var endDate = new DateTimeOffset(2024, 8, 26, 0, 0, 0, TimeSpan.Zero);
        List<DayOfWeek>? requiredDays = null;
        var startTime = new TimeSpan(14, 0, 0);
        var endTime = new TimeSpan(16, 0, 0);
        var limit = 15;
        int? weeksInterval = 1;
        var interval = new TimeSpan(2, 0, 0);
        var occurrence = OccurrenceType.Daily;

        var availableDates = GetNextAvailableDates(currentDate, requiredDays, startTime, endTime, limit, weeksInterval, interval, endDate, occurrence);

        Console.WriteLine("Próximas fechas disponibles:");
        foreach (var date in availableDates)
        {
            Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm"));
        }

        var currentDate2 = new DateTimeOffset(2024, 7, 16, 0, 0, 0, TimeSpan.Zero);
        var endDate2 = new DateTimeOffset(2024, 8, 26, 14, 0, 0, TimeSpan.Zero);
        var requiredDays2 = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Wednesday,
        }; ;
        var startTime2 = new TimeSpan(14, 0, 0);
        var endTime2 = new TimeSpan(16, 0, 0);
        var limit2 = 15;
        int? weeksInterval2 = 2;
        var interval2 = new TimeSpan(2, 0, 0);
        var occurrence2 = OccurrenceType.Weekly;

        var availableDates2 = GetNextAvailableDates(currentDate2, requiredDays2, startTime2, endTime2, limit2, weeksInterval2, interval2, endDate2, occurrence2);
        Console.WriteLine("Próximas fechas disponibles:");
        foreach (var date in availableDates2)
        {
            Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm"));
        }

    }


    public static List<DateTimeOffset> GetNextAvailableDates(
      DateTimeOffset currentDate,
      List<DayOfWeek>? requiredDays,
      TimeSpan startTime,
      TimeSpan endTime,
      int limit,
      int? weeksInterval,
      TimeSpan interval,
      DateTimeOffset endDate,
      OccurrenceType occurrence)
    {
        var availableDates = new List<DateTimeOffset>();
        var referenceDate = currentDate;
        var count = 0;

        var requiredDaysList = GetRequiredDays(requiredDays);
        var weeksIntervalInt = weeksInterval ?? 1;

        while (count < limit && referenceDate <= endDate)
        {
            referenceDate = ProcessWeek(referenceDate, requiredDaysList, startTime, endTime, limit, interval, endDate, ref count, availableDates);
            referenceDate = GetNextReferenceDate(weeksIntervalInt, referenceDate);
        }
       
        return availableDates.Take(limit).ToList();
    }

    private static DateTimeOffset ProcessWeek(DateTimeOffset referenceDate, List<DayOfWeek> requiredDaysList, TimeSpan startTime, TimeSpan endTime, int limit, TimeSpan interval, DateTimeOffset endDate, ref int count, List<DateTimeOffset> availableDates)
    {
        var endOfWeek = referenceDate.AddDays(7 - (int)referenceDate.DayOfWeek);

        for (var date = referenceDate; date <= endOfWeek; date = date.AddDays(1))
        {
            if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
            AddAvailableDatesForDay(date, startTime, endTime, limit, interval, endDate, ref count, availableDates);
        }

        return endOfWeek;
    }

    private static void AddAvailableDatesForDay(DateTimeOffset date, TimeSpan startTime, TimeSpan endTime, int limit, TimeSpan interval, DateTimeOffset endDate, ref int count, List<DateTimeOffset> availableDates)
    {
        var targetDateTime = date.Add(startTime);
        var endTimeDate = date.Add(endTime);

        while (targetDateTime <= endTimeDate && count < limit && targetDateTime <= endDate)
        {
            if (IsWithinTimeFrame(targetDateTime, startTime, endTime))
            {
                availableDates.Add(targetDateTime);
                count++;
            }

            targetDateTime = targetDateTime.Add(interval);
        }
    }

    private static bool IsWithinTimeFrame(DateTimeOffset targetDateTime, TimeSpan startTime, TimeSpan endTime)
    {
        return targetDateTime.TimeOfDay >= startTime && targetDateTime.TimeOfDay <= endTime;
    }

    private static DateTimeOffset GetNextReferenceDate(int weeksIntervalInt, DateTimeOffset date)
    {
        var daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)date.DayOfWeek + 7) % 7;
        var daysUntilStartNextInterval = 7 * (weeksIntervalInt - 1);
        var totalDaysToAdd = daysUntilNextMonday + daysUntilStartNextInterval;

        var nexDate = date.AddDays(totalDaysToAdd);
        var nextTDateReference = new DateTimeOffset(nexDate.Year, nexDate.Month, nexDate.Day, 0, 0, 0, TimeSpan.Zero);

        return nextTDateReference;
    }

    private static List<DayOfWeek> GetRequiredDays(List<DayOfWeek>? days)
    {
        return days ?? new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };
    }


}



