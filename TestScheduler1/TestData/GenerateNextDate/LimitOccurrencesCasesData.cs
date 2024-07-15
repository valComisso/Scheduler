using System.Collections;
using SchedulerClassLibrary.Enums;
using SchedulerClassLibrary.Utils;

namespace Test.TestData.GenerateNextDate
{
    internal class LimitOcurrencesCasesData : IEnumerable<object[]>
    {
        public static IEnumerable<object?[]> Data()
        {
            /*
               uint limit,
               EventType type,
               List<DateTimeOffset>? expectedNextDate,
               string expectedMessage
            */

            // cases with defined limits
            yield return new object?[] {
                2,
                EventType.Recurring,
                new List<DateTimeOffset>() {GenerateDateTimeOffset.Generate(2023, 07, 06), GenerateDateTimeOffset.Generate(2023, 07, 07)},
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
             };

            yield return new object?[] {
                 10,
                 EventType.Recurring,
                 new List<DateTimeOffset>()
                 {
                     GenerateDateTimeOffset.Generate(2023, 07, 06),
                     GenerateDateTimeOffset.Generate(2023, 07, 07),
                     GenerateDateTimeOffset.Generate(2023, 07, 08),
                     GenerateDateTimeOffset.Generate(2023, 07, 09),
                     GenerateDateTimeOffset.Generate(2023, 07, 10),
                     GenerateDateTimeOffset.Generate(2023, 07, 11),
                     GenerateDateTimeOffset.Generate(2023, 07, 12),
                     GenerateDateTimeOffset.Generate(2023, 07, 13),
                     GenerateDateTimeOffset.Generate(2023, 07, 14),
                     GenerateDateTimeOffset.Generate(2023, 07, 15)
                 },
                 $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
             };

        


            yield return new object?[] {
                null,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 06),
                    GenerateDateTimeOffset.Generate(2023, 07, 07),
                    GenerateDateTimeOffset.Generate(2023, 07, 08),
                    GenerateDateTimeOffset.Generate(2023, 07, 09),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };

            yield return new object?[] {
                -1,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 06),
                    GenerateDateTimeOffset.Generate(2023, 07, 07),
                    GenerateDateTimeOffset.Generate(2023, 07, 08),
                    GenerateDateTimeOffset.Generate(2023, 07, 09),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };

            yield return new object?[] {
                -1,
                EventType.Recurring,
                new List<DateTimeOffset>()
                {
                    GenerateDateTimeOffset.Generate(2023, 07, 06),
                    GenerateDateTimeOffset.Generate(2023, 07, 07),
                    GenerateDateTimeOffset.Generate(2023, 07, 08),
                    GenerateDateTimeOffset.Generate(2023, 07, 09),
                    GenerateDateTimeOffset.Generate(2023, 07, 10)
                },
                $"Occurs Recurring. Starting on {GenerateDateTimeOffset.Generate(2023, 07, 01)}."
            };




        }

        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
