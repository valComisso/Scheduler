﻿using SchedulerProject.Entity.DateConfigurations;
using SchedulerProject.UtilsDate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions.Primitives;
using SchedulerProject.Enums;

namespace SchedulerProject.Services
{
    public class AddTimesToDatesService
    {
        public static void AddFixedTime(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DailyFrequencyConfigurations dailyFrequencyConf,
            DateTimeOffset endDate
        )
        {
            var timeFixed = dailyFrequencyConf.FixedTime ?? TimeSpan.Zero;
            if (date.TimeOfDay >= timeFixed) return;

            var targetDateTime = TimeDate.ResetTimeDate(date).Add(timeFixed);

            if (targetDateTime <= endDate && count < limit)
            {
                availableDates.Add(targetDateTime);
                count++;
            }
        }


        public static void AddVariableTimes(
            DateTimeOffset date,
            ref int count,
            List<DateTimeOffset> availableDates,
            int limit,
            DailyFrequencyConfigurations dailyFrequencyConf,
            DateTimeOffset endDate,
            DateTimeOffset referenceDate
        )
        {
            var startTime = dailyFrequencyConf.StartTime ?? TimeSpan.MinValue;
            var endTime = dailyFrequencyConf.EndTime ?? TimeSpan.MaxValue;
            var every = GenerateEveryTimeSpan(dailyFrequencyConf);
            var targetDateTime = SetReferenceDateRecurrentVariableTime(endTime, startTime, date);
            var endTimeDate = TimeDate.ResetTimeDate(date).Add(endTime);

            while (targetDateTime <= endTimeDate && count < limit && targetDateTime <= endDate)
            {

                if (CheckIfWithinTheAllowedTime(targetDateTime, startTime, endTime, referenceDate))
                {
                    availableDates.Add(targetDateTime);
                    count++;
                }
                targetDateTime = targetDateTime.Add(every);
            }
        }



        private static DateTimeOffset SetReferenceDateRecurrentVariableTime(TimeSpan endTime, TimeSpan startTime, DateTimeOffset date)
        {
            var timeDate = date.TimeOfDay;
            if (timeDate < startTime)
            {
                return TimeDate.ResetTimeDate(date).Add(startTime);
            }
            else if (timeDate <= endTime && timeDate >= startTime)
            {
                return date;

            }

            return date;

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
