using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Common
{
    public class DateTimeRange
    {
        public DateTimeRange(DateTime start, DateTime end)
        {
            Guard.ForDateRange(start, end, "start");
            Start = start;
            End = end;
        }

        public DateTimeRange(DateTime start, TimeSpan duration)
            : this(start, start.Add(duration))
        {
        }

        protected DateTimeRange()
        {
        }

        public DateTime Start { get; }
        public DateTime End { get; }

        public int DurationInMinutes()
        {
            return (int)(End - Start).TotalMinutes;
        }

        public DateTimeRange NewEnd(DateTime newEnd)
        {
            return new DateTimeRange(Start, newEnd);
        }

        public DateTimeRange NewDuration(TimeSpan newDuration)
        {
            return new DateTimeRange(Start, newDuration);
        }

        public DateTimeRange NewStart(DateTime newStart)
        {
            return new DateTimeRange(newStart, End);
        }

        public static DateTimeRange CreateOneDayRange(DateTime day)
        {
            return new DateTimeRange(day, day.AddDays(1));
        }

        public static DateTimeRange CreateOneWeekRange(DateTime startDay)
        {
            return new DateTimeRange(startDay, startDay.AddDays(7));
        }

        public bool Overlaps(DateTimeRange dateTimeRange)
        {
            return Start < dateTimeRange.End &&
                   End > dateTimeRange.Start;
        }
    }
}
