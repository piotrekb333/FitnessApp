using FitnessApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Services.Implementations
{
    public class DateTimeProvider : ITimeProvider
    {
        private DateTime _date;

        public DateTime UtcNow
        {
            get { return DateTime.UtcNow; }
        }

        public DateTimeProvider()
        {
            _date = new DateTime();
        }
        public string ToShortDateString()
        {
            return _date.ToShortDateString();
        }
    }
}
