using IEEETalks.Core.Enums;
using System;

namespace IEEETalks.Host.API.Models
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int? Quota { get; set; }
        public DateTime ActivePeriodSince { get; set; }
        public DateTime ActivePeriodUntil { get; set; }
        public float Price { get; set; }
        public EventState EventState { get; set; }
        public DateTime EventDate { get; set; }
    }
}
