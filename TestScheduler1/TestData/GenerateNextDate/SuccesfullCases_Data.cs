using System.Collections;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData.GenerateNextDate
{
    internal class SuccessfullCasesData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
                CurrentDate,
                StatusAvailableType,
                Type,
                Occurrence,
                DateTimeSettings,
                Every,
                StartDate,
                EndDate,
                expectedNextDate
                expectedMessage
            */


            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023,07,01),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2023, 07, 01),
                    GenerateDateTimeOffset.Generate(2023, 07, 03),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                    ),
             new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 03)},
             $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 03)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}." 
            };

            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023,07,01),
                    true,
                    null,
                    OccurrenceType.Daily,
                    0,
                    GenerateDateTimeOffset.Generate(2023, 07, 01),
                    GenerateDateTimeOffset.Generate(2023, 07, 02),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                    ),

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 02)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 02)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."

            };

            yield return new object?[] {
                new DateSettings(  
                    GenerateDateTimeOffset.Generate(2023,07,01),
                    true,
                    null,
                    OccurrenceType.Daily,
                    0,
                    GenerateDateTimeOffset.Generate(2023, 07, 01),
                    null,
                    GenerateDateTimeOffset.Generate(2023, 07, 02)
                    ),

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 02)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 02)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."

            };

            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023,07,01),
                true,
                null,
                OccurrenceType.Daily,
                0,
                GenerateDateTimeOffset.Generate(2023, 07, 05),
                null,
                GenerateDateTimeOffset.Generate(2023, 07, 10)
                    )
                ,

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 05)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2023, 07, 05)} starting on {GenerateDateTimeOffset.Generate(2023, 07, 05)}."

            };

            // Test cases of the first part of the exercise

            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2020,01,04),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    0,
                    GenerateDateTimeOffset.Generate(2020, 01, 01),
                    GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0),
                    null
                    ),
                    new List<DateTimeOffset>() {  GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0)},
                    $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0)} starting on {GenerateDateTimeOffset.Generate(2020, 01, 01)}."

            };

            yield return new object?[] {
                new DateSettings( 
                    GenerateDateTimeOffset.Generate(2020,01,04),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 01, 01),
                    null,
                    null
                    ),
                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2020, 01, 05)},
                $"Occurs Once. Schedule will be used on {GenerateDateTimeOffset.Generate(2020, 01, 05)} starting on {GenerateDateTimeOffset.Generate(2020, 01, 01)}."


            };

            yield return new object?[]
            {
                new DateSettings( 
                    GenerateDateTimeOffset.Generate(2020, 01, 04),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 01, 01),
                    null,
                    null
                    ),
                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2020, 01, 05), GenerateDateTimeOffset.Generate(2020, 01, 06) , GenerateDateTimeOffset.Generate(2020, 01, 07) , GenerateDateTimeOffset.Generate(2020, 01, 08), GenerateDateTimeOffset.Generate(2020, 01, 09) },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2020, 01, 01)}."

            };

            // If not available
            yield return new object?[]
            {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2020, 01, 04),
                    false,
                    EventType.Recurring,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 01, 01),
                    null,
                    null
                ),
                null,
                "It is not possible to calculate the next day"
            };

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
