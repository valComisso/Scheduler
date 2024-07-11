
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Services;
using Test.TestData.GenerateNextDate;

namespace Test.Test
{
    public class DateServiceTests
    {

        [Theory]
        [MemberData(nameof(SuccessfulCasesData.Data), MemberType = typeof(SuccessfulCasesData))]

        public void GenerateNextDate_SuccessfulCases(
            DateSettings dateSettings,
            DateTimeOffset? expectedNextDate
            )
        {

            var service = new DateService(new DateValidator()); 
            var nextDate = service.GenerateNextDate(dateSettings);

            Assert.Equal(expectedNextDate, nextDate?.NextDate);
        }


        [Theory]
        [MemberData(nameof(RangeDateThrowsAnExceptionData.Data), MemberType = typeof(RangeDateThrowsAnExceptionData))]
        [MemberData(nameof(InvalidParamsThrowsAnExceptionData.Data), MemberType = typeof(InvalidParamsThrowsAnExceptionData))]

        public void GenerateNextDate_ThrowsAnException(DateSettings settings)
        {
            var service = new DateService(new DateValidator());

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }


       

    }
}
