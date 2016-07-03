using System;

namespace IEEETalks.Core.Entities
{
    public class EventDate
    {
        public DateTime Date { get; set; }
        public TimeSpan StartAt { get; set; }
        public TimeSpan EndAt { get; set; }
    }
}