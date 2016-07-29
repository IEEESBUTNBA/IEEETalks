using System;
using System.Linq;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;
using IEEETalks.Persistance;
using MediatR;

namespace IEEETalks.CQRS.Queries
{
    public class GetActiveEvents : IRequest<ListResponse<Event>>
    {
        public int Skip { get; }
        public int Limit { get; }

        public GetActiveEvents(int skip, int limit)
        {
            Skip = skip;
            Limit = limit;
        }
    }

    public class GetActiveEventsHandler : IRequestHandler<GetActiveEvents, ListResponse<Event>>
    {
        private readonly ISession _session;

        public GetActiveEventsHandler(ISession session)
        {
            _session = session;
        }

        public ListResponse<Event> Handle(GetActiveEvents message)
        {
            var today = DateTime.Now;

            // TODO: order by something.
            var result = _session.GetQueryable<Event>()
                        .Where(x =>
                               x.EventState == EventState.Active &&
                               x.ActiveSinceDate <= today &&
                               x.ActiveUntilDate >= today
                              )
                        .Skip(message.Skip).Take(message.Limit).ToList();

            var count = _session.GetQueryable<Event>()
                        .Count(x =>
                            x.EventState == EventState.Active &&
                            x.ActiveSinceDate <= today &&
                            x.ActiveUntilDate >= today
                        );

            return new ListResponse<Event>()
            {
                TotalRecords = count,
                Items = result
            };
        }
    }
}
