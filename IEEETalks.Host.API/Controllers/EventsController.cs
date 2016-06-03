using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.Data.Repositories.Interfaces;
using IEEETalks.Host.API.Models;

namespace IEEETalks.Host.API.Controllers
{
    public class EventsController : ApiController
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public EventsController()
        {
            _eventRepository = Container.Current.Resolve<IEventRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, EventDto>()
                    .ForMember(dest => dest.ActivePeriodStart, opt => opt.MapFrom(ol => ol.ActivePeriod.Start))
                    .ForMember(dest => dest.ActivePeriodEnd, opt => opt.MapFrom(ol => ol.ActivePeriod.End));
            });

            _mapper = mapperConfiguration.CreateMapper();
        }

        // GET: api/Events
        public GetEventsResponse Get()
        {
            var result = _eventRepository.GetAll();

            var response = new GetEventsResponse
            {
                Items = _mapper.Map<List<Event>, List<EventDto>>(result.Items),
                TotalRecords = result.TotalRecords
            };

            return response;
        }

        // GET: api/Events/5
        public EventDto Get(string id)
        {
            var result = _eventRepository.GetById(id);

            var response = _mapper.Map<Event, EventDto>(result);

            return response;
        }
    }
}
