using System;

namespace IEEETalks.Host.API.Models
{
    public class InscriptionIntendedRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid EventId { get; set; }
    }
}