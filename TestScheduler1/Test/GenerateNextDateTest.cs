
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Services;
using Test.TestData.GenerateNextDate;

namespace Test.Test
{
    public class DateServiceTests
    {
        /*
        private readonly DateService _service;

        public DateServiceTests()
        {
            var dateValidator = new DateValidator();
            _service = new DateService(dateValidator);
        }


        [Theory]
        [MemberData(nameof(SuccessfulCasesData.Data), MemberType = typeof(SuccessfulCasesData))]

        public void GenerateNextDate_SuccessfulCases(
            DateSettings dateSettings,
            DateTimeOffset? expectedNextDate
            )
        {
            var nextDate = _service.GenerateNextDate(dateSettings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
        }


        [Theory]
        [MemberData(nameof(RangeDateThrowsAnExceptionData.Data), MemberType = typeof(RangeDateThrowsAnExceptionData))]
        [MemberData(nameof(InvalidParamsThrowsAnExceptionData.Data), MemberType = typeof(InvalidParamsThrowsAnExceptionData))]

        public void GenerateNextDate_ThrowsAnException(DateSettings settings)
        {
            Assert.Throws<ArgumentException>(() => _service.GenerateNextDate(settings));
        }


       */

    }
}
