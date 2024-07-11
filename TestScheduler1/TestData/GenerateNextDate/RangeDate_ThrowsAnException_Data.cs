using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchedulerClassLibrary.Entity;

namespace Test.TestData.GenerateNextDate
{
    
    internal class RangeDateThrowsAnExceptionData : IEnumerable<object[]>
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
                    GenerateDateTimeOffset.Generate(2023, 07, 02),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    null,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 01, 01),
                    GenerateDateTimeOffset.Generate(2023, 07, 01)
                )
            };

            yield return new object?[] {
                new DateSettings(
                    GenerateDateTimeOffset.Generate(2023, 07, 06),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    null,
                    1,
                    GenerateDateTimeOffset.Generate(2020, 01, 05),
                    GenerateDateTimeOffset.Generate(2023, 07, 02)
                )
            };

           
            
        }

        public IEnumerator<object?[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
