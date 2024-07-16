using System.Collections;
using SchedulerClassLibrary.Enums;

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
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,3,0,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>() {new DateTimeOffset(2023,7,3,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,3,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };


            // case with if dateTime by configuration, only with currentTime

            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>() {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };


           
            // Controlling that the "every" field does not influence the result

            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                5,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>() {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };

            yield return new object?[] {
               new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                30,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>() {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."

            };

            // test
            yield return new object?[] {
               new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                30,
                new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>() {new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)}."

            };
        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
