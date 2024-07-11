using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerClassLibrary.Entity
{
    public class NextDateResult(string message, DateTimeOffset? nextDate)
    {
        public DateTimeOffset? NextDate { get; set; } = nextDate;
        public string Message { get; set; } = message;
    }
}
