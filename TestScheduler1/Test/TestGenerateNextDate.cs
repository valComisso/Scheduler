
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Entity;
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

            var nextDate = _service.GenerateNextDate(dateSettings, 7);
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
