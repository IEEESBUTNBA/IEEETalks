using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using IEEETalks.Core.Entities;
using IEEETalks.Host.API.Models;
using IEEETalks.CQRS.Queries;
using MediatR;
using System.Web.Http.Cors;

namespace IEEETalks.Host.API.Controllers
{
    public class EventsControllerProfile : Profile
    {
        public EventsControllerProfile()
        {
            CreateMap<Event, GetEventResponse>()
                .ForMember(dest => dest.EventDate, opt => opt.MapFrom(ol => ol.GetFirstEventDate()));
        }
    }
   
    public class EventsController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EventsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/Events
        public GetEventsPagedResponse Get(GetEventsPagedRequest request)
        {
            request = request ?? new GetEventsPagedRequest();

            var result = _mediator.Send(new GetActiveEvents(request.CurrentPage*request.PageSize, request.PageSize));

            var response = new GetEventsPagedResponse
            {
                Items = _mapper.Map<List<Event>, List<GetEventResponse>>(result.Items),
                TotalRecords = result.TotalRecords,
                HasMore = request.HasMore(result.TotalRecords)
            };

            return response;
        }

        // GET: api/Events/{id}
        public GetEventResponse Get(Guid id)
        {
            var result = _mediator.Send(new GetEvent(id));

            var response = _mapper.Map<Event, GetEventResponse>(result);

            return response;
        }
    }
}
