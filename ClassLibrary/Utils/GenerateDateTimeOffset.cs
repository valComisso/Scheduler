using System;

namespace SchedulerClassLibrary.Utils
{
    public class GenerateDateTimeOffset
    {
        public static DateTimeOffset Generate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, DateTimeKind timeKind = DateTimeKind.Local)
        {
            var dateTimeString = $"{year:D4}-{month:D2}-{day:D2}T{hour:D2}:{minute:D2}:{second:D2}";
            const string dateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

            if (!DateTime.TryParseExact(dateTimeString, dateTimeFormat, null, System.Globalization.DateTimeStyles.None, out var dateTime))
            {
                throw new ArgumentException("The provided date and time parameters are invalid.");
            }

            dateTime = DateTime.SpecifyKind(dateTime, timeKind);
            var dto = new DateTimeOffset(dateTime);

            return dto;
        }
    }
}