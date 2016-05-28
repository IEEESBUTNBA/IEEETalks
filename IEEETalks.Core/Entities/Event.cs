using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int? Quota { get; set; }
        public DateTime ActivePeriod { get; set; }
        public float Price { get; set; }
        public EventState eventState { get; set; }
        public DateTime EventDate { get; set; }
        public int MyProperty { get; set; }
    }

    public enum EventState
    {
        Active,
        Suspended,
        Canceled,
        Completed,
        Remove
    }
}
