using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;

namespace IEEETalks.CQS.Infrastructure.Queries
{
    public class GetActiveEvents : IQuery<int, int, ListResponse<Event>>
    {
        private readonly ISession _session;

        public GetActiveEvents(ISession session)
        {
            this._session = session;
        }

        public ListResponse<Event> Run(int skip, int limit)
        {
            var today = DateTime.Now;

            // TODO: order by something.
            var result = this._session.GetQueryable<Event>()
                        .Where( x =>
                                x.EventState == EventState.Active && 
                                x.ActiveStartDate >= today &&
                                x.ActiveEndDate <= today
                              )
                        .Skip(skip).Take(limit).ToList();

            var count = this._session.GetQueryable<Event>()
                        .Count(x =>
                            x.EventState == EventState.Active &&
                            x.ActiveStartDate >= today &&
                            x.ActiveEndDate <= today
                        );                        

            return new ListResponse<Event>()
            {
                TotalRecords = count,
                Items = result
            };
        }
    }
}
