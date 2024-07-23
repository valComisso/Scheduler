using System.Collections;

namespace Test.TestData.GenerateNextDate
{

    internal class RecurringWeeklySuccessfulCasesFixedTime : IEnumerable<object[]>
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
            new TimeSpan(14, 0, 0),
            new List<DayOfWeek>
            {
                DayOfWeek.Monday,
                DayOfWeek.Wednesday,
            },
            new List<DateTimeOffset>()
            {
                new DateTimeOffset(2024,7,3,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,8,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,10,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,15,14,0,0, TimeSpan.Zero),
                new DateTimeOffset(2024,7,17,14,0,0, TimeSpan.Zero)
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
                new TimeSpan(16,30,0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,3,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,10,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,30,0, TimeSpan.Zero)

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
                new TimeSpan(16,30,0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,10,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,11,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,30,0, TimeSpan.Zero)

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
                new TimeSpan(16,30,0),
                new List<DayOfWeek>
                {
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2024,7,3,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,4,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,17,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,18,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,7,31,16,30,0, TimeSpan.Zero),
                    new DateTimeOffset(2024,8,1,16,30,0, TimeSpan.Zero)

                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2024,7,1,0,0,0, TimeSpan.Zero)}."
            };


        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
