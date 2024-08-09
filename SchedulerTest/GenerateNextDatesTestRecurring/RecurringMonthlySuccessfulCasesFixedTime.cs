using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.Services;
using SchedulerTest.TestingUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerTest.GenerateNextDatesTestRecurring
{
    public class RecurringMonthlySuccessfulCasesFixedTime
    {
        [Fact]
        public void return_Upcoming_CurrentTime_Dates_At_Zero_Hours()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 12, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
                FixedTime = new TimeSpan(1, 0, 0)
            };

            var monthlyConfigurations = new MonthlyConfigurations()
            {
                Type = MonthlyConfigurationsType.Day,
                DayNumber = 8,
            };

            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Monthly,
                Every = 2,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations,
                MonthlyConfigurations = monthlyConfigurations
            };



            var nextDates = SchedulerService.GetUpcomingAvailableDates(settings);
            var expectedDates = new List<DateTimeOffset>
            {
                new DateTimeOffset(2023, 7, 8, 1, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 9, 8, 1, 0, 0, TimeSpan.Zero),
                new DateTimeOffset(2023, 11, 8, 1, 0, 0, TimeSpan.Zero),

            };

            var expectedMessage = $"Occurs every 2 months on all days. at 01:00:00. Starting on {startDate}.";

            TestAssertions.AssertUpcomingDates(nextDates, expectedDates, expectedMessage);

        }

    }
}
