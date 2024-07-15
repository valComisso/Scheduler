using System.Collections;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

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
                GenerateDateTimeOffset.Generate(2023,07,02),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 03),
                    GenerateDateTimeOffset.Generate(2023, 07, 04),
                    GenerateDateTimeOffset.Generate(2023, 07, 05)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };

            // case where "startDate" is greater than "currenteDate"
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 01),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 02),
                    GenerateDateTimeOffset.Generate(2023, 07, 03),
                    GenerateDateTimeOffset.Generate(2023, 07, 04),
                    GenerateDateTimeOffset.Generate(2023, 07, 05)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };

           

            // --- Case with dateTime by configuration
            // daily recurrence - 1 days
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                1,
                GenerateDateTimeOffset.Generate(2023, 07, 02),
                GenerateDateTimeOffset.Generate(2023, 07, 05, 14, 0, 0),
                GenerateDateTimeOffset.Generate(2023, 07, 07, 17),
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 05, 14),
                    GenerateDateTimeOffset.Generate(2023, 07, 06, 14),
                    GenerateDateTimeOffset.Generate(2023, 07, 07, 14)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 02)}."
            };

            // daily recurrence - 2 days
            yield return new object?[] {
                GenerateDateTimeOffset.Generate(2023,07,01),
                OccurrenceType.Daily,
                2,
                GenerateDateTimeOffset.Generate(2023, 07, 02),
                GenerateDateTimeOffset.Generate(2023, 07, 05, 14, 0, 0),
                GenerateDateTimeOffset.Generate(2023, 07, 11, 17),
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 05, 14),
                    GenerateDateTimeOffset.Generate(2023, 07, 07, 14),
                    GenerateDateTimeOffset.Generate(2023, 07, 09, 14),
                    GenerateDateTimeOffset.Generate(2023, 07, 11, 14)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 02)}."
            };

       

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
