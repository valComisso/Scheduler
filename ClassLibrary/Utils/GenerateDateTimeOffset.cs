using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerClassLibrary.Utils
{
    public class GenerateDateTimeOffset
    {
        public static DateTimeOffset Generate(int year, int mont, int day, int hour = 0, int minute = 0, int second = 0, DateTimeKind timeKind = DateTimeKind.Local)
        {
            var dateTime = new DateTime(year, mont, day, hour, minute, second, timeKind);
            var dto = new DateTimeOffset(dateTime);

            return dto;
        }

       
    }
}
