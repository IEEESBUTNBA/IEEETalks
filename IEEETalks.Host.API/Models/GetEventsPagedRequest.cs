﻿using System.Web.Http;
using IEEETalks.Common;

namespace IEEETalks.Host.API.Models
{
    [FromUri]
    public class GetEventsPagedRequest : PagedRequest
    {
    }

    public class GetEventsPagedResponse : ListResponse<GetEventResponse>
    {
        public bool HasMore { get; set; }
    }
}