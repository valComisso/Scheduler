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
        var endDate = new DateTimeOffset(2024, 8, 14, 13, 0, 0, TimeSpan.Zero);
        List<DayOfWeek>? requiredDays = new List<DayOfWeek>
        {
            DayOfWeek.Monday,
            DayOfWeek.Wednesday,
        }; 
        var startTime = new TimeSpan(14, 0, 0);
        var endTime = new TimeSpan(16, 0, 0);
        var limit = 15;
        int? weeksInterval = 2;
        var interval = new TimeSpan(14, 0, 0);

        var occurrence = OccurrenceType.Weekly;
        var dailyFrecuencetype = DailyFrecuencyType.Variable;
        var dailyFrecuencyOnceTime = new TimeSpan(15, 0, 0); // horario fijo de todos los dias
        var dailyFrecuencyEvery = new TimeSpan(2, 0, 0); // frecuancia de (horas, min o seg) para cuando el horario no es fijo y hay una franja horaria 
        var availableDates = GetNextAvailableDates(currentDate, requiredDays, startTime, endTime, limit, weeksInterval, interval, endDate, occurrence, dailyFrecuencetype, dailyFrecuencyOnceTime, dailyFrecuencyEvery);

        Console.WriteLine("Próximas fechas disponibles:");
        foreach (var date in availableDates)
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
      OccurrenceType occurrence,
      DailyFrecuencyType dailyFrecuencetype,
      TimeSpan dailyFrecuencyOnceTime,
      TimeSpan dailyFrecuencyEvery
      )
    {
        var availableDates = new List<DateTimeOffset>();
        var referenceDate = currentDate;
        var count = 0;

        var requiredDaysList = GetRequiredDays(requiredDays);
        var weeksIntervalInt = weeksInterval ?? 1;

        while (count < limit && referenceDate <= endDate)
        {
            referenceDate = ProcessInteval(referenceDate, requiredDaysList, startTime, endTime, limit, interval, endDate, ref count, availableDates, dailyFrecuencetype, dailyFrecuencyOnceTime, occurrence, dailyFrecuencyEvery);
            referenceDate = GetNextIntervalStart(referenceDate, occurrence, weeksIntervalInt);
        }

        return availableDates.Take(limit).ToList();
    }

    private static DateTimeOffset ProcessInteval(DateTimeOffset referenceDate, List<DayOfWeek> requiredDaysList, TimeSpan startTime, TimeSpan endTime, int limit, TimeSpan interval, DateTimeOffset endDate, ref int count, List<DateTimeOffset> availableDates, DailyFrecuencyType dailyFrecuencetype, TimeSpan dailyFrecuencyOnceTime, OccurrenceType occurrence, TimeSpan dailyFrecuencyEvery)
    {
        var daysProcess = occurrence switch
        {
            OccurrenceType.Daily => 0,
            OccurrenceType.Weekly => 7 - (int)referenceDate.DayOfWeek,
            _ => 0
        };

        var endOfProcess = referenceDate.AddDays(daysProcess);

        for (var date = referenceDate; date <= endOfProcess; date = date.AddDays(1))
        {
            if (!requiredDaysList.Contains(date.DayOfWeek)) continue;
            AddAvailableDatesForDay(date, startTime, endTime, limit, interval, endDate, ref count, availableDates, dailyFrecuencetype, dailyFrecuencyOnceTime, dailyFrecuencyEvery);
        }

        return endOfProcess;
    }

    private static void AddAvailableDatesForDay(DateTimeOffset date, TimeSpan startTime, TimeSpan endTime, int limit, TimeSpan interval, DateTimeOffset endDate, ref int count, List<DateTimeOffset> availableDates, DailyFrecuencyType dailyFrecuencetype, TimeSpan dailyFrecuencyOnceTime, TimeSpan dailyFrecuencyEvery)
    {
        if (dailyFrecuencetype == DailyFrecuencyType.Fixed)
        {
            if (date.TimeOfDay > dailyFrecuencyOnceTime ) return;
            var dateWithoutTime = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
            var targetDateTime = dateWithoutTime.Add(dailyFrecuencyOnceTime);

            if(targetDateTime > endDate) return;
            availableDates.Add(targetDateTime);
            count++;


        }
        else if (dailyFrecuencetype == DailyFrecuencyType.Variable)
        {
            if (date.TimeOfDay > endTime ) return;

            var dateWithoutTime = new DateTimeOffset(date.Year, date.Month, date.Day, 0, 0, 0, date.Offset);
            var targetDateTime = date;
            var endTimeDate = date.Add(endTime);

            while (targetDateTime <= endTimeDate && count < limit && targetDateTime <= endDate)
            {

                if (IsWithinTimeFrame(targetDateTime, startTime, endTime))
                {
                    availableDates.Add(targetDateTime);
                    count++;
                }

                targetDateTime = targetDateTime.Add(dailyFrecuencyEvery);
            }
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

    private static DateTimeOffset GetNextIntervalStart(DateTimeOffset currentDate, OccurrenceType occurrence, int every)
    {
        DateTimeOffset nexDate;
        DateTimeOffset nextTDateReference;
        switch (occurrence)
        {
            case OccurrenceType.Daily:
                nexDate = currentDate.AddDays(1);
                nextTDateReference = new DateTimeOffset(nexDate.Year, nexDate.Month, nexDate.Day, 0, 0, 0, TimeSpan.Zero);

                return nextTDateReference;
            case OccurrenceType.Weekly:
                {
                    var daysUntilNextMonday = ((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek + 7) % 7;
                    var daysUntilStartNextInterval = 7 * (every - 1);
                    var totalDaysToAdd = daysUntilNextMonday + daysUntilStartNextInterval;

                    nexDate = currentDate.AddDays(totalDaysToAdd);
                    nextTDateReference = new DateTimeOffset(nexDate.Year, nexDate.Month, nexDate.Day, 0, 0, 0, TimeSpan.Zero);
                    return nextTDateReference;
                }
            default:
                throw new ArgumentOutOfRangeException(nameof(occurrence), occurrence, null);
        }
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



