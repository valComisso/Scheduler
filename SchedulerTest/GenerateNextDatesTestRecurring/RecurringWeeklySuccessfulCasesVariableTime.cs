using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                StartTime = new TimeSpan(12,0,0),
                EndTime = new TimeSpan(17,0,0),
                Every = new TimeSpan(2,0,0)
               
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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 8, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 8, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 8, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 10, 12, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 10, 14, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 10, 16, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[9].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[10].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[11].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[12].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[13].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[14].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 22, 12, 0, 0, TimeSpan.Zero), nextDates[15].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 22, 14, 0, 0, TimeSpan.Zero), nextDates[16].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 22, 16, 0, 0, TimeSpan.Zero), nextDates[17].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);
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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";

            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

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
                Every = new TimeSpan(2, 0, 0)

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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 12, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 14, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 16, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[8].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

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
                Every = new TimeSpan(2, 0, 0)
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

            var expectedMessage = $"Occurs Recurring. Starting on {startDate}.";
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 15, 0, 0, TimeSpan.Zero), nextDates[0].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 3, 17, 0, 0, TimeSpan.Zero), nextDates[1].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 12, 0, 0, TimeSpan.Zero), nextDates[2].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 14, 0, 0, TimeSpan.Zero), nextDates[3].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 15, 16, 0, 0, TimeSpan.Zero), nextDates[4].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 12, 0, 0, TimeSpan.Zero), nextDates[5].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 14, 0, 0, TimeSpan.Zero), nextDates[6].NextDate);
            Assert.Equal(new DateTimeOffset(2024, 7, 17, 16, 0, 0, TimeSpan.Zero), nextDates[7].NextDate);
            Assert.Equal(expectedMessage, nextDates[0].Message);

        }


    }
}
