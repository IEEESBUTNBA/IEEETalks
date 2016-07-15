using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.CQS.Infrastructure.Queries;
using IEEETalks.Host.API.Models;
using System.Web.Http.Cors;

namespace IEEETalks.Host.API.Controllers
{
    [EnableCorsAttribute("http://localhost:56951","*","*")]
    public class EventsController : ApiController
    {
        //private readonly ICommandBus _commandBus;
        private readonly GetActiveEvents _getActiveEventsQuery;
        private readonly GetEvent _getEventQuery;

        private readonly IMapper _mapper;

        public EventsController()
        {
            //_commandBus = Container.Current.Resolve<ICommandBus>();
            _getActiveEventsQuery = Container.Current.Resolve<GetActiveEvents>();
            _getEventQuery = Container.Current.Resolve<GetEvent>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, GetEventResponse>()
                    .ForMember(dest => dest.EventDate, opt => opt.MapFrom(ol => ol.GetFirstEventDate()));
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        // GET: api/Events
        public GetEventsPagedResponse Get([FromUri]GetEventsPagedRequest request)
        {
            request = request ?? new GetEventsPagedRequest();

            var result = _getActiveEventsQuery.Run(request.CurrentPage * request.PageSize, request.PageSize);

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
            var result = _getEventQuery.Run(id);

            var response = _mapper.Map<Event, GetEventResponse>(result);

            return response;
        }
    }
}
