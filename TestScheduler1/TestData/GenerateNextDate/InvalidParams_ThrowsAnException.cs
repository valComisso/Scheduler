using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;
using System.Collections;
using SchedulerClassLibrary.Entity;

namespace Test.TestData.GenerateNextDate
{
    internal class InvalidParamsThrowsAnExceptionData : IEnumerable<object[]>
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
            
            */

            // DateTimeSettings must be larger than CurrentDate
            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023,07,01),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2023, 07, 01),
                    GenerateDateTimeOffset.Generate(2023, 06, 03),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                    )
            };

            // The DateTime date of the settings is not within the allowed range.

            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023,07,01),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2023, 07, 01),
                    GenerateDateTimeOffset.Generate(2023, 07, 13),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                    )
                
            };

            // EndDate must be larger than StartDate
            yield return new object?[] {
               new DateSettings(
                   GenerateDateTimeOffset.Generate(2023,07,01),
                   true,
                   EventType.Once,
                   OccurrenceType.Daily,
                   1,
                   GenerateDateTimeOffset.Generate(2023, 07, 15),
                   null,
                   GenerateDateTimeOffset.Generate(2023, 07, 10)
                   )
            };


            // The DateTime date of the settings is not within the allowed range.
            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023, 07, 07),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 07, 05),
                    GenerateDateTimeOffset.Generate(2020, 07, 15),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                )
            };

            // Current time Same as End Time
            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023, 07, 07),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 07, 05),
                    null,
                    GenerateDateTimeOffset.Generate(2023, 07, 07)
                )
            };





        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
