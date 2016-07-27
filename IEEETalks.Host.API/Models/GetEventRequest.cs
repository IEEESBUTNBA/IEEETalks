using IEEETalks.Core.Enums;
using System;

namespace IEEETalks.Host.API.Models
{
    //public class GetEventRequest
    //{
    //    public Guid Id { get; set; }
    //}

    public class GetEventResponse
    {
        public Guid Id { get; set; }
        public int EntityId { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Location { get; set; }
        public int? Quota { get; set; }
        public DateTime ActiveSinceDate { get; set; }
        public DateTime ActiveUntilDate { get; set; }
        public float Price { get; set; }
        public EventState EventState { get; set; }
        public DateTime EventDate { get; set; }
    }
}
