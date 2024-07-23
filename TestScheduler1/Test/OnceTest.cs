using SchedulerClassLibrary.DateServices;
using SchedulerClassLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using Test.TestData.GenerateNextDate;

namespace Test.Test
{
    public class OnceTest
    {
        private readonly DateService _service;

        public OnceTest()
        {
            var dateValidator = new DateValidator();
            _service = new DateService(dateValidator);
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

    }
}
