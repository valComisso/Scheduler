using SchedulerClassLibrary;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.UseCasesDate;
using Test.TestData;
using Test.TestData.GenerateNextDate;

namespace Test 
{
    public class DateServiceTests
    {

        [Theory]
        [MemberData(nameof(SuccessfulCasesData.Data), MemberType = typeof(SuccessfulCasesData))]

        public void GenerateNextDate_SuccessfulCases(
            DateTimeOffset currentDate,
            bool statusAvailableType,
            EventType type,
            OccurrenceType occurs,
            DateTimeOffset? dateTimeSettings,
            int every,
            DateTimeOffset startDate,
            DateTimeOffset? endDate,
            DateTimeOffset expectedNextDate
            )
        {
           
            var settings = new DateSettings
            {
                CurrentDate = currentDate,
                StatusAvailableType = statusAvailableType,
                Type = type,
                Occurrence = occurs,
                DateTimeSettings = dateTimeSettings,
                Every = every,
                StartDate = startDate,
                EndDate = endDate
            };

            var service = new DateService(new DateValidator());
            var nextDate = service.GenerateNextDate(settings);

            Assert.Equal(expectedNextDate, nextDate);
        }




        [Theory]
        [MemberData(nameof(RangeDateThrowsAnExceptionData.Data), MemberType = typeof(RangeDateThrowsAnExceptionData))]

        public void GenerateNextDate_rangeDate_ThrowsAnException(DateTimeOffset currentDate, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            var settings = new DateSettings

            {
                CurrentDate = currentDate,
                StartDate = startDate,
                EndDate = endDate
            };

            var service = new DateService(new DateValidator());

            Assert.Throws<ArgumentException>(() => service.GenerateNextDate(settings));
        }


      
    }
}
