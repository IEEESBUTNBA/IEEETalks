using System;
using System.Linq;
using IEEETalks.Core.Entities;

namespace IEEETalks.CQS.Infrastructure.Queries
{
    public class GetEvent : IQuery<Guid, Event>
    {
        private readonly ISession _session;

        public GetEvent(ISession session)
        {
            this._session = session;
        }

        public Event Run(Guid id)
        {
            var result = this._session.GetQueryable<Event>()
                            .FirstOrDefault(x => x.Id == id);

            return result;
        }
    }
}
