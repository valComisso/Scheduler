using System.Collections;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData.GenerateNextDate
{
    internal class OnceSuccessfulCasesData : IEnumerable<object[]>
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
               expectedNextDate
            */

            // case with dateTime by configuration

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                GenerateDateTimeOffset.Generate(2023, 07, 3),
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 03)}
            };


            // case with if dateTime by configuration, only with currentTime

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)}
            };


            // Controlling that the "occurrence" field does not influence the result

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Weekly,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)}
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Monthly,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)}
            };


            // Controlling that the "every" field does not influence the result

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                5,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)}
            };

            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                30,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 7),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 02)}
            };

            // test
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                30,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 10),
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 05)}
            };
        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
