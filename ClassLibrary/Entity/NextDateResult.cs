using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerClassLibrary.Entity
{
    public class NextDateResult(string message, List<DateTimeOffset> nextDate)
    {
        public List<DateTimeOffset> NextDate { get; } = nextDate;
        public string Message { get; } = message;
    }
}
