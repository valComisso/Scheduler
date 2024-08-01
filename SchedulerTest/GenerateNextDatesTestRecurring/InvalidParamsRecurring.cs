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
    public class InvalidParamsRecurring
    {
        [Fact]
        public void return_Exception_Because_Every_Is_Zero()
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
                Every = 0,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };


            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));


        }

        [Fact]
        public void return_Exception_Because_Missing_FixedTime_In_DailyFrequencyConfigurations()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Fixed,
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

        [Fact]
        public void return_Exception_Because_Missing_StartTime_In_DailyFrequencyConfigurations()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                EndTime = new TimeSpan(12,0,0),
                Every = 3,
                EveryType = EveryType.Hours
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

        [Fact]
        public void return_Exception_Because_Missing_EndTime_In_DailyFrequencyConfigurations()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                Every = 3,
                EveryType = EveryType.Hours
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

        [Fact]
        public void return_Exception_Because_Missing_Every_In_DailyFrequencyConfigurations()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(3, 0, 0)
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

        [Fact]
        public void return_Exception_Because_StartTime_Is_Greater_Than_EndTime()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                Type = DailyFrequencyType.Variable,
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(3, 0, 0),
                Every = 1,
                EveryType = EveryType.Hours
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

        [Fact]
        public void return_Exception_Because_Missing_Type_In_DailyFrequencyConfigurations()
        {
            var currentDate = new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero);


            var startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            var endDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            var limits = new LimitsConfigurations(startDate, endDate);

            var frequencyConfigurations = new DailyFrequencyConfigurations()
            {
                StartTime = new TimeSpan(12, 0, 0),
                EndTime = new TimeSpan(3, 0, 0),
                Every = 1,
                EveryType = EveryType.Hours
            };


            var settings = new DateConfigurations(currentDate)
            {
                Type = EventType.Recurring,
                Occurrence = OccurrenceType.Weekly,
                Every = 1,
                Limits = limits,
                FrequencyConfigurations = frequencyConfigurations
            };

            Assert.Throws<ArgumentException>(() => SchedulerService.GetUpcomingAvailableDates(settings));

        }

    }
}
