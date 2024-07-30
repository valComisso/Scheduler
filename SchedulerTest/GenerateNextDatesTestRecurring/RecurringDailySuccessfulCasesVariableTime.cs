using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;

namespace SchedulerTest.GenerateNextDatesTestRecurring
{
    public class RecurringDailySuccessfulCasesVariableTime
    {
        // tests with different END DATES
        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_EndDateTime_Minor_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_EndDateTime_Inside_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_EndDateTime_Greater_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 17, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[12].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero), nextDates[13].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 14, 0, 0, TimeSpan.Zero), nextDates[14].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero), nextDates[15].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_EndDateTime_Equal_To_Start_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[12].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_EndDateTime_Equal_To_End_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[12].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero), nextDates[13].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 14, 0, 0, TimeSpan.Zero), nextDates[14].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero), nextDates[15].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }


        // tests with different CURRENT DATE
        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_currentDateTime_Minor_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 11, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_currentDateTime_Inside_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_currentDateTime_Greater_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 20, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 17, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_currentDateTime_Equal_To_Start_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 13, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero), nextDates[12].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 14, 0, 0, TimeSpan.Zero), nextDates[13].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero), nextDates[14].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_currentDateTime_Equal_To_End_TimeRange()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 13, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 13, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 15, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 12, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 13, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }


        // Different frequency settings
        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_StartTime_Equal_Than_EndTime()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(12, 0, 0),
                Every = new TimeSpan(1, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }

        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_Frequency_Every_2_Hours()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(15, 0, 0),
                Every = new TimeSpan(2, 0, 0),
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Daily,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2023, 7, 2, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 2, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 12, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2023, 7, 4, 14, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);

            Assert.Equal(expectedMessage, nextDates[0].Message);

        }
    }
}
