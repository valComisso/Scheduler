using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.Enums;
using SchedulerProject.UtilsDate;

namespace SchedulerProject.Validator
{
    public static class ValidateConfigurations
    {
        public static void ValidateTheCompleteConfiguration(DateConfigurations configurations)
        {
            if (!configurations.StatusAvailableType)
            {
                throw new ArgumentException("It is not possible to calculate the next day");
            }

            if (configurations.Type == EventType.Once)
            {
                ValidateOnceConfigurations(configurations);
            }
            else if (configurations.Type == EventType.Recurring)
            {
                ValidateRecurringConfigurations(configurations);
            }
        }

        private static void ValidateOnceConfigurations(DateConfigurations configurations)
        {
            if (configurations.DateTimeSettings == null) return;
            if (configurations.DateTimeSettings < configurations.CurrentDate)
            {
                throw new ArgumentException("DateTimeSettings must be larger than CurrentDate.");
            }
            ;
            if (!DateValidator.DateRangeValidator(configurations.DateTimeSettings.Value, configurations.Limits))
            {
                throw new ArgumentException("The DateTime date of the settings is not within the allowed range.");
            }
        }

        private static void ValidateRecurringConfigurations(DateConfigurations configurations)
        {
            if (configurations.Every is null or 0)
            {
                throw new ArgumentException(" Every must be counted on");
            }


            var frequencyType = configurations.FrequencyConfigurations!.Type ?? null;
            var fixedTime = configurations.FrequencyConfigurations!.FixedTime ?? null;
            var startTime = configurations.FrequencyConfigurations!.StartTime ?? null;
            var endTime = configurations.FrequencyConfigurations!.EndTime ?? null;
            var every = configurations.FrequencyConfigurations!.Every ?? null;

            switch (frequencyType)
            {
                case DailyFrequencyType.Fixed when fixedTime == null:
                    throw new ArgumentException("The fixed time for each date must be defined");
                case DailyFrequencyType.Variable when startTime == null || endTime == null || every == null:
                    throw new ArgumentException("Invalid parameters for setting schedules by date");
                case DailyFrequencyType.Variable when startTime > endTime :
                    throw new ArgumentException("Invalid Time Limit Parameters");

                case null:
                    throw new ArgumentException("A frequency type must be defined for the generation of the next dates");
            }
        }
    }
}
