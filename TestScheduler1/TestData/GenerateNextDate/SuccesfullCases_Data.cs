using System.Collections;
using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;

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
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    true,
                    null,
                    OccurrenceType.Daily,
                    0,
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                    ),

                new List<DateTimeOffset>() { new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."

            };

            yield return new object?[] {
                new DateSettings(  
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    true,
                    null,
                    OccurrenceType.Daily,
                    0,
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)
                    ),

                new List<DateTimeOffset>() { new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,2,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero)}."

            };

            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                true,
                null,
                OccurrenceType.Daily,
                0,
                new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero),
                null,
                new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                    )
                ,

                new List<DateTimeOffset>() { new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2023,7,5,0,0,0, TimeSpan.Zero)}."

            };

            // Test cases of the first part of the exercise

            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2020,1,4,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    0,
                    new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2020,1,8,14,0,0, TimeSpan.Zero),
                    null
                    ),
                    new List<DateTimeOffset>() {  new DateTimeOffset(2020,1,8,14,0,0, TimeSpan.Zero)},
                    $"Occurs Once. Schedule will be used on {new DateTimeOffset(2020,1,8,14,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero)}."

            };

            yield return new object?[] {
                new DateSettings( 
                    new DateTimeOffset(2020,1,4,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero),
                    null,
                    null
                    ),
                new List<DateTimeOffset>() { new DateTimeOffset(2020,1,5,0,0,0, TimeSpan.Zero)},
                $"Occurs Once. Schedule will be used on {new DateTimeOffset(2020,1,5,0,0,0, TimeSpan.Zero)} starting on {new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero)}."


            };
           

            yield return new object?[]
            {
                new DateSettings( 
                    new DateTimeOffset(2020,1,4,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero),
                    null,
                    null
                    )
                {
                    DailyFrequencyType = DailyFrecuencyType.Fixed,
                    DailyFrequencyFixedTime =  new TimeSpan(20,0,0)
                },
                new List<DateTimeOffset>()
                {
                    new DateTimeOffset(2020,1,4,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,5,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,6,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,7,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,8,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,9,20,0,0, TimeSpan.Zero), 
                    new DateTimeOffset(2020,1,10,20,0,0, TimeSpan.Zero),
                },
                $"Occurs Recurring. Starting on {new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero)}."

            };
     
            // If not available
            yield return new object?[]
            {
                new DateSettings(
                    new DateTimeOffset(2020,1,4,0,0,0, TimeSpan.Zero),
                    false,
                    EventType.Recurring,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2020,1,1,0,0,0, TimeSpan.Zero),
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
