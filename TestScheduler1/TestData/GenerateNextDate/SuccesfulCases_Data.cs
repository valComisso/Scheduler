using System.Collections;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData.GenerateNextDate
{
    internal class SuccessfulCasesData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
            yield return new object?[] {
                CurrentDate,
                StatusAvailableType,
                Type,
                Occurrence,
                DateTimeSettings,
                Every,
                StartDate,
                EndDate,
                expectedNextDate
            };
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
             new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 03)} 
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

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 02)}
               
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

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 02)}
              
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

                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2023, 07, 05)}
        
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
                    new List<DateTimeOffset>() {  GenerateDateTimeOffset.Generate(2020, 01, 08, 14, 0,0)}
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
                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2020, 01, 05)}
               
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
                new List<DateTimeOffset>() { GenerateDateTimeOffset.Generate(2020, 01, 05), GenerateDateTimeOffset.Generate(2020, 01, 06) , GenerateDateTimeOffset.Generate(2020, 01, 07) , GenerateDateTimeOffset.Generate(2020, 01, 08), GenerateDateTimeOffset.Generate(2020, 01, 09) }
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
                null
            };

        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
