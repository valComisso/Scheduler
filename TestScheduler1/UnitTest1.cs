using System;
using Scheduler.Library;
using Xunit;

namespace MyProject.Tests
{
    public class DateServiceTests
    {
        [Theory]
        [InlineData("2023-07-01", true, "Recurring", "2023-07-03", 1, "2023-07-01", "2023-07-10", "2023-07-04")] 
        [InlineData("2023-07-01", false, null, "2023-07-02", 0, "2023-07-01", "2023-07-10", "2023-07-02")]
        [InlineData("2023-07-01", false, null, "2023-07-02", 0, null, "2023-07-10", "2023-07-02")]
        public void GenerateNextDate_SuccessfulCases(
         string currentDate, bool statusAvailableType, string type, object dateTimeSettings,
         int every, string startDate, string endDate, string expectedNextDate)
        {
            var settings = new DateSettings
            {
                CurrentDate = currentDate,
                StatusAvailableType = statusAvailableType,
                Type = type,
                DateTimeSettings = dateTimeSettings,
                Every = every,
                StartDate = startDate, // Se pasa como cadena
                EndDate = endDate // Se pasa como cadena
            };

            var service = new DateService();
            var nextDate = service.GenerateNextDate(settings);

            Assert.Equal(DateTime.Parse(expectedNextDate), nextDate);
        }



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



    }
}
