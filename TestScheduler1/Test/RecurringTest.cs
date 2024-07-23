using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.TestData.GenerateNextDate;

namespace Test.Test
{
    public class TestRecurringGenerateNextDate
    {
        private readonly DateService _service;

        public TestRecurringGenerateNextDate()
        {
            var dateValidator = new DateValidator();
            _service = new DateService(dateValidator);
        }

      
        [Theory]
        [MemberData(nameof(RecurringDailySuccessfulCasesFixedTime.Data), MemberType = typeof(RecurringDailySuccessfulCasesFixedTime))]

        public void SuccessfulCases_RecurringDailyFixedTime(
            DateTimeOffset currentDate,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            TimeSpan? fixedTime,
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Recurring,
                OccurrenceType.Daily,
                every,
                startDate,
                dateTimeSettings,
                endDate
            )
            {
                DailyFrequencyType = DailyFrecuencyType.Fixed,
                DailyFrequencyFixedTime = fixedTime
            };


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);
        }

        [Theory]
        [MemberData(nameof(RecurringDailySuccessfulCasesVariableTimeData.Data), MemberType = typeof(RecurringDailySuccessfulCasesVariableTimeData))]

        public void SuccessfulCases_RecurringDailyVariableTime(
            DateTimeOffset currentDate,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            TimeSpan? endTime,
            TimeSpan? startTime,
            TimeSpan? intervalTime,
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Recurring,
                OccurrenceType.Daily,
                every,
                startDate,
                dateTimeSettings,
                endDate
            )
            {
                DailyFrequencyType = DailyFrecuencyType.Variable,
                DailyFrequencyEndTime = endTime,
                DailyFrequencyStartTime = startTime,
                DailyFrequencyEvery = intervalTime
            };


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);
        }

        [Theory]
        [MemberData(nameof(RecurringWeeklySuccessfulCasesFixedTime.Data), MemberType = typeof(RecurringWeeklySuccessfulCasesFixedTime))]

        public void SuccessfulCases_RecurringWeeklyFixedTime(
            DateTimeOffset currentDate,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            TimeSpan? fixedTime,
            List<DayOfWeek> days, 
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Recurring,
                OccurrenceType.Weekly,
                every,
                startDate,
                dateTimeSettings,
                endDate
            )
            {
                DailyFrequencyType = DailyFrecuencyType.Fixed,
                DailyFrequencyFixedTime = fixedTime,
                WeeklySettingsSelectedDays = days

            };


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);
        }


        [Theory]
        [MemberData(nameof(RecurringWeeklySuccessfulCasesVariableTime.Data), MemberType = typeof(RecurringWeeklySuccessfulCasesVariableTime))]

        public void SuccessfulCases_RecurringWeeklyVariableTime(
            DateTimeOffset currentDate,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            TimeSpan? endTime,
            TimeSpan? startTime,
            TimeSpan? intervalTime,
            List<DayOfWeek> days,
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Recurring,
                OccurrenceType.Weekly,
                every,
                startDate,
                dateTimeSettings,
                endDate
            )
            {
                DailyFrequencyType = DailyFrecuencyType.Variable,
                DailyFrequencyEndTime = endTime,
                DailyFrequencyStartTime = startTime,
                DailyFrequencyEvery = intervalTime,
                WeeklySettingsSelectedDays = days

            };


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);
        }

       
    }

}
