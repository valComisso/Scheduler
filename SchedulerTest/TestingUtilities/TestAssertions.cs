using FluentAssertions;
using SchedulerProject.Entity.Results;

namespace SchedulerTest.TestingUtilities
{
    public static class TestAssertions
    {
        public static void AssertUpcomingDates(
            List<DateResult> nextDates,
            List<DateTimeOffset> expectedDates,
            string expectedMessage)
        {
            nextDates.Should().HaveCount(expectedDates.Count, "because the number of upcoming dates should match the expected count");

            for (var i = 0; i < expectedDates.Count; i++)
            {
                nextDates.ElementAt(i).NextDate.Should().Be(expectedDates[i], $"because the next date at index {i} should match the expected date");
            }

            nextDates.First().Message.Should().Be(expectedMessage, "because the message for the first upcoming date should match the expected message");
        }
    }

}
