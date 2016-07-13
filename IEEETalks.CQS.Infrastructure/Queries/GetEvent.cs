using System;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Persistance;

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

            Guard.ForNull(result, "Event", $"id:{id}", "The event is not found.");

            return result;
        }
    }
}
