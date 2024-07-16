using System.Collections;
using SchedulerClassLibrary.Enums;

namespace Test.TestData.GenerateNextDate
{
    internal class LimitOcurrencesCasesData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               uint limit,
               EventType type,
               List<DateTimeOffset>? expectedNextDate,
               string expectedMessage
            */

            // cases with defined limits
            yield return new object?[] {
                2,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,6,0,0,0, TimeSpan.Zero),  
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)
                }."
             };

            yield return new object?[] {
                 10,
                 EventType.Recurring,
                 new List<DateTimeOffset>()
                 {
                     new DateTimeOffset(2023,7,6,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,8,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,9,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,11,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,12,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,13,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,14,0,0,0, TimeSpan.Zero),
                     new DateTimeOffset(2023,7,15,0,0,0, TimeSpan.Zero)
                 },
                 $"Occurs Recurring. Starting on { new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
             };

        


            yield return new object?[] {
                null,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,6,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,8,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,9,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on { new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };

            yield return new object?[] {
                -1,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,6,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,8,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,9,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };

          




        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
