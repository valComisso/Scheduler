using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Services
{
    public static class AddTimesToDatesService
    {
        public static void AddFixedTime(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            DateConfigurations configurations
        )
        {

            var dailyFrequencyConf = configurations.FrequencyConfigurations;
            if (dailyFrequencyConf == null) return;
            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;
            var timeFixed = dailyFrequencyConf.FixedTime ?? TimeSpan.Zero;

            if (date.TimeOfDay >= timeFixed) return;

            var targetDateTime = TimeDate.ResetTimeDate(date).Add(timeFixed);

            if (targetDateTime <= endDate)
            {
                availableDates.Add(targetDateTime);
                count++;
            }
        }

        public static void AddVariableTimes(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            DateConfigurations configurations,
            DateTimeOffset referenceDate
        )
        {
            var dailyFrequencyConf = configurations.FrequencyConfigurations;
            if (dailyFrequencyConf == null) return;
            var endDate = configurations.Limits.EndDate ?? DateTimeOffset.MaxValue;
            var startTime = dailyFrequencyConf.StartTime ?? TimeSpan.MinValue;
            var endTime = dailyFrequencyConf.EndTime ?? TimeSpan.MaxValue;
            var every = GenerateEveryTimeSpan(dailyFrequencyConf);
            var targetDateTime = SetReferenceDateRecurrentVariableTime(startTime, date);
            var endTimeDate = TimeDate.ResetTimeDate(date).Add(endTime);

            while (targetDateTime <= endTimeDate && targetDateTime <= endDate)
            {

                if (CheckIfWithinTheAllowedTime(targetDateTime, startTime, endTime, referenceDate))
                {
                    availableDates.Add(targetDateTime);
                    count++;
                }
                targetDateTime = targetDateTime.Add(every);
            }
        }

        private static DateTimeOffset SetReferenceDateRecurrentVariableTime(TimeSpan startTime, DateTimeOffset date)
        {
            var timeDate = date.TimeOfDay;
            return timeDate < startTime ? TimeDate.ResetTimeDate(date).Add(startTime) : date;
        }
        
        private static bool CheckIfWithinTheAllowedTime(DateTimeOffset targetDateTime, TimeSpan startTime, TimeSpan endTime, DateTimeOffset referenceDate)
        {
            var timeOfDay = targetDateTime.TimeOfDay;
            return timeOfDay >= startTime && timeOfDay <= endTime && targetDateTime > referenceDate;
        }

        private static TimeSpan GenerateEveryTimeSpan(DailyFrequencyConfigurations configurations)
        {
            var every = configurations.Every ?? 1;

            TimeSpan time = TimeSpan.Zero;

            switch (configurations.EveryType)
            {
                case EveryType.Hours:
                    time = new TimeSpan(every, 0, 0);
                    break;
                case EveryType.Minutes:
                    time = new TimeSpan(0, every, 0);
                    break;
                case EveryType.Seconds:
                    time = new TimeSpan(0, 0, every);
                    break;
            }

            return time;
        }

    }
}
