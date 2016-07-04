using System;
using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.CQS.Infrastructure.Queries;
using IEEETalks.Host.API.Models;

namespace IEEETalks.Host.API.Controllers
{
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
                cfg.CreateMap<Event, EventDto>()
                    .ForMember(dest => dest.EventDate, opt => opt.MapFrom(ol => ol.GetFirstEventDate()));
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        // GET: api/Events
        public GetEventsResponse Get()
        {
            // TODO: add logic to paginate.
            var result = _getActiveEventsQuery.Run(0, 100);

            var response = new GetEventsResponse
            {
                Items = _mapper.Map<List<Event>, List<EventDto>>(result.Items),
                TotalRecords = result.TotalRecords
            };

            return response;
        }

        // GET: api/Events/{id}
        public EventDto Get(Guid id)
        {
            var result = _getEventQuery.Run(id);

            var response = _mapper.Map<Event, EventDto>(result);

            this.ValidateNull(response, $"The event is not found (id: {id})");

            return response;
        }
    }
}
