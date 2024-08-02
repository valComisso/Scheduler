using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;
using SchedulerTest.TestingUtilities;

namespace SchedulerTest.GenerateNextDatesTestRecurring
{
    public class RecurringWeeklySuccessfulCasesVariableTime
    {
        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Zero_Hours()
        {
            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 23, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };

            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 8, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 8, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 8, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 10, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 10, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 10, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 22, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 22, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 22, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 1 week on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        [Fact]
        public void return_Upcoming_CurrentTime_Every_Two_Weeks()
        {

            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 23, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };

            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);
        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_With_Only_One_Day_Of_The_Week_Allowed()
        {

            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 23, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);
        }

        // tests with different End dates
        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Greater_Than_TimeRange()
        {

            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Minor_Than_TimeRange()
        {

            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 11, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_EndTime_Within_the_TimeRange()
        {

            var currentDate = new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);
        }


        // tests with different Start dates

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Greater_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 18, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Minor_Than_TimeRange()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 11, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours

            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Specific_Time_StartTime_Within_The_TimeRange()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 13, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(17, 0, 0),
                Every = 2,
                EveryType = EveryType.Hours
            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 15, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 3, 17, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 2 hours between 12:00:00 and 17:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }


        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_Frequency_Every_1_Hour()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 13, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(14, 0, 0),
                Every = 1,
                EveryType = EveryType.Hours
            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 13, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 13, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 1 hour between 12:00:00 and 14:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }


        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_Frequency_Every_30_Minutes()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 13, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(13, 0, 0),
                Every =30,
                EveryType = EveryType.Minutes
            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 13, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 30, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 13, 0, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 30 minutes between 12:00:00 and 13:00:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }


        [Fact]
        public void return_Upcoming_Dates_Within_The_Available_Time_Range_Frequency_Every_60_seconds()
        {
            var currentDate = new DateTimeOffset(2024, 7, 3, 13, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2024, 7, 17, 18, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(12, 5, 0),
                Every = 60,
                EveryType = EveryType.Seconds
            };

            var weeklyConfigurations = new WeeklyConfigurations()
            {
                SelectedDays = [
                    DayOfWeek.Monday,
                    DayOfWeek.Wednesday,
                ]
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                WeeklyConfigurations = weeklyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);

            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 1, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 2, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 3, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 4, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 15, 12, 5, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 1, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 2, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 3, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 4, 0, TimeSpan.Zero),
                new DateTimeOffset(2024, 7, 17, 12, 5, 0, TimeSpan.Zero),
            };

            var expectedMessage = $"Occurs every 2 weeks on Monday and Wednesday every 60 seconds between 12:00:00 and 12:05:00. Starting on {startDate}.";


            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);


        }


    }
}
