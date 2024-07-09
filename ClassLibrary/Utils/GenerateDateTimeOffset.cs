
namespace SchedulerClassLibrary.Utils
{
    public class GenerateDateTimeOffset
    {
        public static DateTimeOffset Generate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0, DateTimeKind timeKind = DateTimeKind.Local)
        {
            ValidateYear(year);
            ValidateMonth(month);
            ValidateDay(year, month, day);
            ValidateHour(hour);
            ValidateMinute(minute);
            ValidateSecond(second);

            var dateTime = new DateTime(year, month, day, hour, minute, second, timeKind);
            var dto = new DateTimeOffset(dateTime);

            return dto;
        }

        private static void ValidateYear(int year)
        {
            if (year is < 1 or > 9999)
                throw new ArgumentOutOfRangeException(nameof(year), "Year must be between 1 and 9999");
        }

        private static void ValidateMonth(int month)
        {
            if (month is < 1 or > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12");
        }

        private static void ValidateDay(int year, int month, int day)
        {
            if (day < 1 || day > DateTime.DaysInMonth(year, month))
                throw new ArgumentOutOfRangeException(nameof(day), "Day must be valid for the given month and year");
        }

        private static void ValidateHour(int hour)
        {
            if (hour is < 0 or > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "Hour must be between 0 and 23");
        }

        private static void ValidateMinute(int minute)
        {
            if (minute is < 0 or > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), "Minute must be between 0 and 59");
        }

        private static void ValidateSecond(int second)
        {
            if (second is < 0 or > 59)
                throw new ArgumentOutOfRangeException(nameof(second), "Second must be between 0 and 59");
        }
    }
}

