using System.Collections;

namespace Test.TestData.GenerateNextDate
{

    internal class RecurringWeeklySuccessfulCasesVariableTime : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               DateTimeOffset currentDate,
               uint every,
               DateTimeOffset startDate,
               DateTimeOffset? dateTimeSettings,
               DateTimeOffset? endDate,
               TimeSpan? endTime,
               TimeSpan? startTime,
               TimeSpan? intervalTime,
               List<DayOfWeek> days,
               List<DateTimeOffset>? expectedNextDate,
               string expectedMessage
            */


            // With INTERCALATED ALLOWED DAYS
            yield return new object?[] {
            new DateTimeOffset(2024, 7, 2, 0, 0, 0, TimeSpan.Zero),
            1,
            new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero),
            null,
            new DateTimeOffset(2024, 7, 20, 0, 0, 0, TimeSpan.Zero),
            new TimeSpan(18, 0, 0),
            new TimeSpan(16, 0, 0),
            new TimeSpan(1, 0, 0),
            new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Wednesday,
            },
            new List<DateTimeOffset>()
            {
                new DateTimeOffset(2024,7,3,16,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,3,17,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,3,18,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,8,16,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,8,17,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,8,18,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,10,16,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,10,17,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,10,18,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,15,16,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,15,17,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,15,18,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,17,16,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,17,17,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,17,18,0,0, TimeSpan.Zero)
            },
            $"Occurs Recurring. Starting on {new DateTimeOffset(2024, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With CONSECUTIVE DAYS allowed
            yield return new object?[] {
                new DateTimeOffset(2024,7,2,17,0,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2024,7,20,16,30,0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,18,0,0, TimeSpan.Zero)

                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero)}."
            };


            // with the start of the time interval GREATER than currentDate
            yield return new object?[] {
                new DateTimeOffset(2024,7,2,17,0,0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2024,7,10,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2024,7,20,16,30,0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,10,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,18,0,0, TimeSpan.Zero)

                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2024,7,10,0,0,0, TimeSpan.Zero)}."
            };

            // with an INTERVAL of 2 WEEKS
            yield return new object?[] {
                new DateTimeOffset(2024,7,2,17,0,0, TimeSpan.Zero),
                2,
                new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2024,8,5,16,30,0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,18,0,0, TimeSpan.Zero)

                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero)}."
            };

            // with an INTERVAL of 2 WEEKS and every 2 HOURS
            yield return new object?[] {
                new DateTimeOffset(2024,7,2,17,0,0, TimeSpan.Zero),
                2,
                new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2024,8,5,16,30,0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(2, 0, 0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,18,0,0, TimeSpan.Zero)

                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero)}."
            };

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
