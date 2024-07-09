using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.TestData.GenerateNextDate
{
    internal class InvalidParamsThrowsAnExceptionData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               yield return new object?[] {
                   CurrentDate,
                   StatusAvailableType,
                   Type,
                   Occurrence,
                   DateTimeSettings,
                   Every,
                   StartDate,
                   EndDate,
                   expectedNextDate
               };
            */

            // DateTimeSettings must be larger than CurrentDate
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                GenerateDateTimeOffset.Generate(2023, 06, 03),
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 03)
            };

            // The DateTime date of the settings is not within the allowed range.

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                GenerateDateTimeOffset.Generate(2023, 07, 13),
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 03)
            };

            // EndDate must be larger than StartDate
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                null,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 15),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 03)
            };



        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
