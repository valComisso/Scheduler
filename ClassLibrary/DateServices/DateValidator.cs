﻿using SchedulerClassLibrary.Interfaces;

namespace SchedulerClassLibrary.DateServices
{
    public class DateValidator : IDateValidator
    {
        public bool DateRangeValidator(DateTimeOffset date, DateTimeOffset startDate, DateTimeOffset? endDate)
        {
            return endDate == null || date <= endDate;
        }
    }
}