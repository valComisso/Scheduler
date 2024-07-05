using System;
using SchedulerClassLibrary;
using Xunit;
using static SchedulerClassLibrary.DateSettings;

namespace MyProject.Tests
{
    public class DateServiceTests
    {
        [Theory]
        [InlineData("2023-07-01", true, EventType.Once,OccurrenceType.Daily, "2023-07-03", 1, "2023-07-01", "2023-07-10", "2023-07-03")] 
        [InlineData("2023-07-01", false, null, OccurrenceType.Daily, "2023-07-02", 0, "2023-07-01", "2023-07-10", "2023-07-02")]
        [InlineData("2023-07-01", false, null, OccurrenceType.Daily, "2023-07-02", 0, null, "2023-07-10", "2023-07-02")]

        // casos de prueba del ejercicio 
        [InlineData("2020-01-04", true, EventType.Once, OccurrenceType.Daily, "08/01/2020 14:00:00", 0, "2020-01-01", null, "08/01/2020 14:00:00")]
        [InlineData("2020-01-04", true, EventType.Recurring, OccurrenceType.Daily, null,1, "2020-01-01", null, "2020-01-05")]


        public void GenerateNextDate_SuccessfulCases(
            DateTimeOffset currentDate, bool statusAvailableType, EventType type, OccurrenceType occurs, DateTimeOffset dateTimeSettings,
         int every, DateTimeOffset startDate, DateTimeOffset endDate, DateTimeOffset expectedNextDate)
        {
            var settings = new DateSettings
            {
                CurrentDate = currentDate,
                StatusAvailableType = statusAvailableType,
                Type = type,
                Occurrence = occurs,
                DateTimeSettings = dateTimeSettings,
                Every = every,
                StartDate = startDate, 
                EndDate = endDate 
            };

            var service = new DateService();
            var nextDate = service.GenerateNextDate(settings);
            var expectedDate = DateValidator.ConvertToDateTime(expectedNextDate);

            Assert.Equal(expectedDate, nextDate);
        }


/*
        [Theory]
        [InlineData("", "2023-07-01", "2023-07-10")] // StartDate vacío
        [InlineData("4defebrero", "2023-07-01", "2023-07-10")] // StartDate formato incorrecto
        [InlineData("5", "2023-07-01", "2023-07-10")] // StartDate tipo incorrecto
        [InlineData("2023-07-01", "", "2023-07-10")] // EndDate vacío
        [InlineData("2023-07-01", "4defebrero", "2023-07-10")] // EndDate formato incorrecto
        [InlineData("2023-07-01", "5", "2023-07-10")] // EndDate tipo incorrecto
        public void GenerateNextDate_ThrowsAnException(
            string startDate, string endDate, string currentDate)
        {
            var settings = new DateSettings
            {
                CurrentDate = currentDate,
                StartDate = startDate,
                EndDate = endDate
            };

            var service = new DateService();

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }


        [Theory]
        [InlineData("")]
        [InlineData("4defebrero")]
        [InlineData(null)]
        [InlineData("5")]
        public void GenerateNextDate_currentDate_ThrowsAnException(string currentDate)
        {
            var settings = new DateSettings
            
            {
                CurrentDate = currentDate
            };

            var service = new DateService();

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }

        [Theory]
        [InlineData("2023-07-01", "")] 
        [InlineData("2023-07-01", 5)]
        [InlineData("2023-07-01", "4defebrero")]
        [InlineData("2023-07-01", "4564564156456")]
        public void GenerateNextDate_dateTimeSettings_ThrowsAnException(string currentDate, object dateTimeSettings)
        {
            var settings = new DateSettings

            {
                CurrentDate = currentDate,
                DateTimeSettings = dateTimeSettings,
            };

            var service = new DateService();

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }

        */

    }
}
