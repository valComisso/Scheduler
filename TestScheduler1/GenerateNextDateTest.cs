using SchedulerClassLibrary;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.DateServices;

namespace Test 
{
    public class DateServiceTests
    {
        [Theory]
        [InlineData("2023-07-01", true, EventType.Once, OccurrenceType.Daily, "2023-07-03", 1, "2023-07-01", "2023-07-10", "2023-07-03")]
        [InlineData("2023-07-01", false, null, OccurrenceType.Daily, "2023-07-02", 0, "2023-07-01", "2023-07-10", "2023-07-02")]
        [InlineData("2023-07-01", false, null, OccurrenceType.Daily, null, 0, "2023-07-05", "2023-07-10", "2023-07-06")]

        // casos de prueba del ejercicio 
        [InlineData("2020-01-04", true, EventType.Once, OccurrenceType.Daily, "08/01/2020 14:00:00", 0, "2020-01-01",null, "08/01/2020 14:00:00")]
        [InlineData("2020-01-04", true, EventType.Recurring, OccurrenceType.Daily, null, 1, "2020-01-01", null, "2020-01-05")]


        public void GenerateNextDate_SuccessfulCases(
            string currentDate, bool statusAvailableType, EventType type, OccurrenceType occurs, string? dateTimeSettings,
         int every, string startDate, string? endDate, string expectedNextDate)
        {
            var current = DateTimeOffset.Parse(currentDate);
            var start = DateTimeOffset.Parse(startDate);
            var expected = DateTimeOffset.Parse(expectedNextDate);
            DateTimeOffset? dateTime = string.IsNullOrEmpty(dateTimeSettings) ? null : DateTimeOffset.Parse(dateTimeSettings);
            DateTimeOffset? end = string.IsNullOrEmpty(endDate) ? null : DateTimeOffset.Parse(endDate);
           
            var settings = new DateSettings
            {
                CurrentDate = current,
                StatusAvailableType = statusAvailableType,
                Type = type,
                Occurrence = occurs,
                DateTimeSettings = dateTime,
                Every = every,
                StartDate = start, 
                EndDate = end
            };

            var service = new DateService(new DateValidator());
            var nextDate = service.GenerateNextDate(settings);
            var expectedDate = expected;

            Assert.Equal(expectedDate, nextDate);
        }

        [Theory]
        [InlineData("2023-07-02", "2020-01-01", "2023-07-01")] // currendDate Fuera de rango
        [InlineData("2023-07-6", "2020-07-05", "2023-07-2")] // endDate Fuera de rango

        public void GenerateNextDate_rangeDate_ThrowsAnException(string currentDate, string startDate, string? endDate)
        {
            DateTimeOffset current = DateTimeOffset.Parse(currentDate);
            DateTimeOffset start = DateTimeOffset.Parse(startDate);
            DateTimeOffset? end = string.IsNullOrEmpty(endDate) ? null : DateTimeOffset.Parse(endDate);

            var settings = new DateSettings

            {
                CurrentDate = current,
                StartDate = start,
                EndDate = end
            };

            var service = new DateService(new DateValidator());

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }


       

    }
}
