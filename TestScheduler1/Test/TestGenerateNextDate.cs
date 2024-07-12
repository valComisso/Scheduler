
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
using SchedulerClassLibrary.Utils;
using Test.TestData.GenerateNextDate;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Test.Test
{
    public class TestGenerateNextDate
    {
        private readonly DateService _service;

        public TestGenerateNextDate()
        {
            var dateValidator = new DateValidator();
            _service = new DateService(dateValidator);
        }


        [Theory]
        [MemberData(nameof(SuccessfulCasesData.Data), MemberType = typeof(SuccessfulCasesData))]

        public void GenerateNextDate_SuccessfulCases(
            DateSettings dateSettings,
           List<DateTimeOffset>? expectedNextDate
        )
        {

            var nextDate = _service.GenerateNextDate(dateSettings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.False(string.IsNullOrEmpty(nextDate?.Message), "The message should not be null or empty");

        }

        [Theory]
        [MemberData(nameof(OnceSuccessfulCasesData.Data), MemberType = typeof(OnceSuccessfulCasesData))]

        public void GenerateNextDate_SuccessfulCases_Once(
            DateTimeOffset currentDate,
            OccurrenceType occurrence,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            List<DateTimeOffset>? expectedNextDate
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Once,
                occurrence,
                every,
                startDate,
                dateTimeSettings,
                endDate
            );


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
        }

        [Theory]
        [MemberData(nameof(RecurringSuccessfullCasesData.Data), MemberType = typeof(RecurringSuccessfullCasesData))]

        public void GenerateNextDate_SuccessfulCases_Recurring(
            DateTimeOffset currentDate,
            OccurrenceType occurrence,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            List<DateTimeOffset>? expectedNextDate
        )
        {

            var settings = new DateSettings(
                currentDate,
                true,
                EventType.Recurring,
                occurrence,
                every,
                startDate,
                dateTimeSettings,
                endDate
            );


            var nextDate = _service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
        }

      

        [Theory]
        [MemberData(nameof(InvalidParamsThrowsAnExceptionData.Data), MemberType = typeof(InvalidParamsThrowsAnExceptionData))]

        public void GenerateNextDate_ThrowsAnException(DateSettings settings)
        {
            Assert.Throws<ArgumentException>(() => _service.GenerateNextDate(settings));
        }



    }
}
