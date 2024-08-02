using FluentAssertions;
using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;
using SchedulerTest.TestingUtilities;

namespace SchedulerTest.GenerateNextDatesTestRecurring
{
    public class RecurringDailySuccessfulCasesFixedTime
    {

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Zero_Hours()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(1, 0, 0)
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
            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 2, 1, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 3, 1, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 1, 0, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 01:00:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        // tests with different End dates
        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Greater_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 17, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 17, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Minor_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 17, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);
        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Equal_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 17, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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


            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }


        // tests with different Start dates

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Greater_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 17, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 6, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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


            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Minor_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 16, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 15, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 2, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Equal_Than_Fixed_Time()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 16, 30, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(16, 30, 0)
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

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 3, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 4, 16, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 7, 5, 16, 30, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 1 day on all days. at 16:30:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);
        }



    }
}
