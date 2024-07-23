using SchedulerClassLibrary.Entity;
using SchedulerClassLibrary.Enums;
using System.Collections;

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
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,6,3,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                    )
            };

            // The DateTime date of the settings is not within the allowed range.

            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,13,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                    )

            };

            // EndDate must be larger than StartDate
            yield return new object?[] {
               new DateSettings(
                   new DateTimeOffset(2023,7,1,0,0,0, TimeSpan.Zero),
                   true,
                   EventType.Once,
                   OccurrenceType.Daily,
                   1,
                   new DateTimeOffset(2023,7,15,0,0,0, TimeSpan.Zero),
                   null,
                   new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                   )
            };


            // The DateTime date of the settings is not within the allowed range.
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2020,7,15,0,0,0, TimeSpan.Zero),
                    new DateTimeOffset(2023,7,10,0,0,0, TimeSpan.Zero)
                )
            };

            // Current time Same as End Time
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Once,
                    OccurrenceType.Daily,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
            };

            // every is cero and is Recurring
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Daily,
                    0,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
            };
           
            // Weekly without day selection
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Weekly,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
            };

            // with a fixed schedule without specifying it
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Weekly,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
                {
                    DailyFrequencyType = DailyFrecuencyType.Fixed,
                    WeeklySettingsSelectedDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Wednesday,
                        DayOfWeek.Thursday
                    },
                }
            };
          
            // Variable weekly without any necessary parameter
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Weekly,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
                {
                    DailyFrequencyType = DailyFrecuencyType.Variable,
                    WeeklySettingsSelectedDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Wednesday,
                        DayOfWeek.Thursday
                    },
                    DailyFrequencyStartTime = new TimeSpan(12,0,0)
                }
            };

            //Indefinite frequency type
            yield return new object?[] {
                new DateSettings(
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero),
                    true,
                    EventType.Recurring,
                    OccurrenceType.Weekly,
                    1,
                    new DateTimeOffset(2020,7,5,0,0,0, TimeSpan.Zero),
                    null,
                    new DateTimeOffset(2023,7,7,0,0,0, TimeSpan.Zero)
                )
                {
                    WeeklySettingsSelectedDays = new List<DayOfWeek>
                    {
                        DayOfWeek.Wednesday,
                        DayOfWeek.Thursday
                    },
                    DailyFrequencyStartTime = new TimeSpan(12,0,0)
                }
            };


        }


        public IEnumerator<object[]> GetEnumerator() => Data().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
