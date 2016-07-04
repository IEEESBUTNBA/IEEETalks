using System;
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
            var result = this._session.GetById<Event>(id);

            return result;
        }
    }
}
