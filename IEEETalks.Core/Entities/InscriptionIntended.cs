using System;

namespace IEEETalks.Core.Entities
{
    public class InscriptionIntended
    {
        public InscriptionIntended()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid EventId { get; set; }
    }
}
