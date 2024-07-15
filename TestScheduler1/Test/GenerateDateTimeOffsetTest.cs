using SchedulerClassLibrary.Utils;

namespace Test.Test
{
    public class GenerateDateTimeOffsetTests
    {
        [Fact]
        public void Generate_ValidDate_ReturnsExpectedDateTimeOffset()
        {
           
            const int year = 2024;
            const int month = 7;
            const int day = 9;
            const int hour = 12;
            const int minute = 30;
            const int second = 45;
            const DateTimeKind timeKind = DateTimeKind.Utc;

         
            var result = GenerateDateTimeOffset.Generate(year, month, day, hour, minute, second, timeKind);

       
            var expected = new DateTimeOffset(new DateTime(year, month, day, hour, minute, second, timeKind));
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(0, 7, 9, 0, 0, 0, "year")] // Year out of range
        [InlineData(2024, 0, 9, 0, 0, 0, "month")] // Month out of range
        [InlineData(2024, 7, 0, 0, 0, 0, "day")] // Day out of range
        [InlineData(2024, 2, 30, 0, 0, 0, "day")] // Invalid day in February
        [InlineData(2024, 7, 9, 24, 0, 0, "hour")] // Hour out of range
        [InlineData(2024, 7, 9, -5, 0, 0, "hour")] // Hour out of range
        [InlineData(2024, 7, 9, 23, 60, 0, "minute")] // Minute out of range
        [InlineData(2024, 7, 9, 23, -1, 0, "minute")] // Minute out of range
        [InlineData(2024, 7, 9, 23, 59, -1, "second")] // Second out of range
        public void Generate_InvalidParameters_ThrowsArgumentOutOfRangeException(int year, int month, int day, int hour, int minute, int second, string expectedParamName)
        {
            
            Assert.Throws<ArgumentException>(() => GenerateDateTimeOffset.Generate(year, month, day, hour, minute, second));
        }
    }
}
