using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;

namespace SchedulerTest.GenerateNextDateTestOnce
{
    public class InvalidParamsOnce
    {
        [Fact]
        public void return_Exception_When_CurrentTime_Is_Less_Than_CurrentDate()
        {
            var currentDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                DateTimeSettings = new DateTimeOffset(2023, 6, 3, 11, 0, 0, TimeSpan.Zero),
                Every = 1,
                Limits = limits

            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));
        }

        [Fact]
        public void return_Exception_Because_CurrentTime_Is_Out_Of_Limits()
        {
            var currentDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                DateTimeSettings = new DateTimeOffset(2023, 8, 3, 11, 0, 0, TimeSpan.Zero),
                Every = 1,
                Limits = limits

            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));
        }

        [Fact]
        public void return_Exception_Because_CurrentTime_Same_As_EndTime()
        {
            var currentDate = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits

            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));
        }

        [Fact]
        public void return_Exception_Because_StatusAvailableType_Is_False()
        {
            var currentDate = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                StatusAvailableType = false

            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));
        }

        [Fact]
        public void return_Exception_Because_EndDate_Is_Less_Than_StartDate()
        {
            var startDate = new DateTimeOffset(2023, 7, 10, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            Assert.Throws<ArgumentException>(() => new LimitsConfigurations(startDate, endDate));
        }

        [Fact]
        public void return_Exception_Because_The_Date_Doesnt_Exist()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new DateTimeOffset(2024, 2, 30, 0, 0, 0, TimeSpan.Zero));
        }
    }
}
