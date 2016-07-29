using System;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Persistance;
using MediatR;

namespace IEEETalks.CQRS.Queries
{
    public class GetEvent : IRequest<Event>
    {
        public Guid Id { get; }

        public GetEvent(Guid id)
        {
            Id = id;
        }
    }

    public class GetEventHandler : IRequestHandler<GetEvent, Event>
    {
        private readonly ISession _session;
        private readonly IGuard _guard;

        public GetEventHandler(ISession session, IGuard guard)
        {
            _session = session;
            _guard = guard;
        }

        public Event Handle(GetEvent message)
        {
            var result = _session.GetById<Event>(message.Id);

            _guard.ForNull(result, "EventNotFounded", $"id:{message.Id}", "The event is not found.");

            return result;
        }
    }
}
