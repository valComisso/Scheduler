using System.Collections;

namespace Test.TestData.GenerateNextDate
{

    internal class RecurringDailySuccessfulCasesVariableTimeData : IEnumerable<object[]>
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
               List<DateTimeOffset>? expectedNextDate,
               string expectedMessage
            */


            // daily recurring case, in a limited period of time
            // END DATE
            // With time WITHIN the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 17, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,17,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time LESS than the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time GREATER than the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 21, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time EQUAL to START of the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 16, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,16,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time EQUAL to END of the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 0, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 18, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,5,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // CURRENT DATE
            // with time WITHIN the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 17, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            //  With time LESS than the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 15, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time GREATER than the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 20, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time EQUAL to START of the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 16, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };

            // With time EQUAL to END of the time range
            yield return new object?[] {
                new DateTimeOffset(2023, 7, 2, 18, 0, 0, TimeSpan.Zero),
                1,
                new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023, 7, 5, 0, 0, 0, TimeSpan.Zero),
                new TimeSpan(18, 0, 0),
                new TimeSpan(16, 0, 0),
                new TimeSpan(1, 0, 0),
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2023,7,2,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,3,18,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,16,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,17,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,4,18,0,0, TimeSpan.Zero)
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2023, 7, 1, 0, 0, 0, TimeSpan.Zero)}."
            };
        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
