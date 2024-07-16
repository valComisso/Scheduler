
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Services;
using Test.TestData.GenerateNextDate;

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
        [MemberData(nameof(SuccessfullCasesData.Data), MemberType = typeof(SuccessfullCasesData))]

        public void GenerateNextDate_SuccessfulCases(
            DateSettings dateSettings,
           List<DateTimeOffset>? expectedNextDate, 
            string expectedMessage
        )
        {

            var nextDate = _service.GenerateNextDate(dateSettings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);

        }

        [Theory]
        [MemberData(nameof(OnceSuccessfullCasesData.Data), MemberType = typeof(OnceSuccessfullCasesData))]

        public void GenerateNextDate_SuccessfulCases_Once(
            DateTimeOffset currentDate,
            OccurrenceType occurrence,
            uint every,
            DateTimeOffset startDate,
            DateTimeOffset? dateTimeSettings,
            DateTimeOffset? endDate,
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage 
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
            Assert.Equal(expectedMessage, nextDate?.Message);
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
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
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
            Assert.Equal(expectedMessage, nextDate?.Message);
        }


        [Theory]
        [MemberData(nameof(LimitOcurrencesCasesData.Data), MemberType = typeof(LimitOcurrencesCasesData))]

        public void GenerateNextDate_LimitOccurrencesCases(
            int? limit,
            EventType type,
            List<DateTimeOffset>? expectedNextDate,
            string expectedMessage
        )
        {
            DateTimeOffset currentDate = new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset startDate = new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero);
            DateTimeOffset endDate = new DateTimeOffset(2023, 7, 20, 0, 0, 0, TimeSpan.Zero);

            var settings = new DateSettings(
                currentDate,
                true,
                type,
                OccurrenceType.Daily,
                1,
                startDate,
                null,
                endDate
            );


            var nextDate = _service.GenerateNextDate(settings, limit);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
            Assert.Equal(expectedMessage, nextDate?.Message);
        }


        [Theory]
        [MemberData(nameof(InvalidParamsThrowsAnExceptionData.Data), MemberType = typeof(InvalidParamsThrowsAnExceptionData))]

        public void GenerateNextDate_ThrowsAnException(DateSettings settings)
        {
            Assert.Throws<ArgumentException>(() => _service.GenerateNextDate(settings));
        }



    }
}
