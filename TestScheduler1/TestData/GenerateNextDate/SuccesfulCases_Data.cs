using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData
{
    internal class SuccessfulCasesData : IEnumerable<object[]>
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

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                GenerateDateTimeOffset.Generate(2023, 07, 03),
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 03)
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                false,
                null,
                OccurrenceType.Daily,
                GenerateDateTimeOffset.Generate(2023, 07, 02),
                0,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 02)
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                false,
                null,
                OccurrenceType.Daily,
                null,
                0,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                GenerateDateTimeOffset.Generate(2023, 07, 06)
            };

            // Test cases of the first part of the exercise

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2020,01,04),
                true,
                EventType.Once,
                OccurrenceType.Daily,
                GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0),
                0,
                GenerateDateTimeOffset.Generate(2020, 01, 01),
                null,
                GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0)
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2020,01,04),
                true,
                EventType.Recurring,
                OccurrenceType.Daily,
                null,
                1,
                GenerateDateTimeOffset.Generate(2020, 01, 01),
                null,
                GenerateDateTimeOffset.Generate(2020, 01, 05)
            };


        }

        public IEnumerator<object?[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
