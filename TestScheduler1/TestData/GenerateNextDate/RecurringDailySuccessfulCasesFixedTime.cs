using System.Collections;

namespace Test.TestData.GenerateNextDate
{

    internal class RecurringDailySuccessfulCasesFixedTime : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               DateTimeOffset currentDate,
               uint every,
               DateTimeOffset startDate,
               DateTimeOffset? dateTimeSettings,
               DateTimeOffset? endDate,
               TimeSpan? fixedTime,
               List<DateTimeOffset>? expectedNextDate,
               string expectedMessage
            */


            // case of daily recurrence, always at the same time
            // --- case only with currentTime, at zero hours

            yield return new object?[] {
            new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,1,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,1,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,1,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // --- case only with currentTime, at a specific time
            yield return new object?[] {
                new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,5,16,30,0, TimeSpan.Zero),
                new TimeSpan(16,30,0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,3,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,16,30,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };



            yield return new object?[] {
                new DateTimeOffset(2023,7,2,16,30,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,5,17,30,0, TimeSpan.Zero),
                new TimeSpan(17,0,0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,17,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };



            // case where "startDate" is greater than "currenteDate"
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero),
                new TimeSpan(17,0,0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,1,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."
            };


            // --- Case with dateTime by configuration
            // daily recurrence - 1 days
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,4,0,0,0, TimeSpan.Zero),
                new TimeSpan(14,0,0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,14,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)}."
            };


            // daily recurrence - 2 days
            yield return new object?[] {
                new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                2,
                new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,5,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2023,7,5,17,0,0, TimeSpan.Zero),
                new TimeSpan(14,0,0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,14,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,14,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)}."
            };

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
