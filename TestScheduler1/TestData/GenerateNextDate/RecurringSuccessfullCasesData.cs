using System.Collections;
using SchedulerClassLibrary.Enums;

namespace Test.TestData.GenerateNextDate
{
    internal class RecurringSuccessfullCasesData : IEnumerable<object[]>
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


            // --- case only with currentTime 
            // normal case
            yield return new object?[] {
                new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,3,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };

            // case where "startDate" is greater than "currenteDate"
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };

           

            // --- Case with dateTime by configuration
            // daily recurrence - 1 days
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                1,
                new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,5,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,7,17,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,5,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,6,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,7,14,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)}."
            };

            // daily recurrence - 2 days
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                OccurrenceType.Daily,
                2,
                new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,5,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,11,17,0,0, TimeSpan.Zero),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,5,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,7,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,9,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,11,14,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)}."
            };

       

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
