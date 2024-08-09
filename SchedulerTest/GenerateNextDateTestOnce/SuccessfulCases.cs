using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;

namespace SchedulerTest.GenerateNextDateTestOnce
{
    public class SuccessfulCases
    {
        [Fact]
        public void return_The_Next_Available_Date_From_The_CurrentTime_Setting()
        {
            var currentDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                DateTimeSettings = new DateTimeOffset(2023, 7, 3, 0, 0, 0, TimeSpan.Zero),
                Every = 1,
                Limits = limits

            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedNextDates = new DateTimeOffset(2023, 7, 3, 0, 0, 0, TimeSpan.Zero);
            var expectedMessage =
                $"Occurs Once. Schedule will be used on " +
                $"{new DateTimeOffset(2023, 7, 3, 0, 0, 0, TimeSpan.Zero)}" +
                $" starting on " +
                $"{new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}.";

            Assert.Equal(expectedNextDates, nextDates[0].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
        }


        [Fact]
        public void return_The_Next_Available_Date_From_CurrentDate()
        {
            var currentDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);


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


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedNextDates = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);
            var expectedMessage =
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}.";

            Assert.Equal(expectedNextDates, nextDates[0].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
        }


        [Fact]
        public void Return_The_Next_Date_Without_Taking_Into_Account_Every()
        {
            var currentDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 7, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                Every = 30,
                Limits = limits

            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedNextDates = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);
            var expectedMessage =
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}.";

            Assert.Equal(expectedNextDates, nextDates[0].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
        }

        [Fact]
        public void Return_The_Day_After_The_29th_Of_File()
        {
            var currentDate = new DateTimeOffset(2024, 2, 29, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 3, 10, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Once,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits

            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedNextDates = new DateTimeOffset(2024, 3, 1, 0, 0, 0, TimeSpan.Zero);
            var expectedMessage =
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2024, 3, 1, 0, 0, 0, TimeSpan.Zero)} starting on {new DateTimeOffset(2024, 2, 1, 0, 0, 0, TimeSpan.Zero)}.";

            Assert.Equal(expectedNextDates, nextDates[0].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
        }


    }
}
