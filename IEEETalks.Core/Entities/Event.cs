using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Core.Enums;
using IEEETalks.Common;

namespace IEEETalks.Core.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int? Quota { get; set; }
        public DateTime ActiveStartDate { get; set; }
        public DateTime ActiveEndDate { get; set; }
        public float Price { get; set; }
        public EventState EventState { get; set; }
        public List<EventDate> EventDates { get; set; }

        public Event()
        {
            this.Id = Guid.NewGuid();
            this.EventDates = new List<EventDate>();
        }

        public DateTime GetFirstEventDate()
        {
            var result = this.EventDates.Min(x => x.Date + x.StartAt);
            return result;
        }
    }
}
