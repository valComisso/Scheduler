using System.Collections;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData.GenerateNextDate
{
    internal class OnceSuccessfullCasesData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               currentDate,
               occurrence,
               every,
               startDate,
               dateTimeSettings,
               endDate,
               expectedNextDate,
               expectedMessage
            */

            // case with dateTime by configuration

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 3),
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 03)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 03)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };


            // case with if dateTime by configuration, only with currentTime

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 02)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };


           
            // Controlling that the "every" field does not influence the result

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                5,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 02)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                30,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 02)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."

            };

            // test
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                30,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 05)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 05)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 05)}."

            };
        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
