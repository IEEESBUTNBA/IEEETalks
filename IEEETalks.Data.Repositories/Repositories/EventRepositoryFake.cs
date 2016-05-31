using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;
using IEEETalks.Data.Repositories.Interfaces;
using IEEETalks.Data.Repositories.Shared;

namespace IEEETalks.Data.Repositories.Repositories
{
    public class EventRepositoryFake : BaseRepository<Event>, IEventRepository
    {
        public EventRepositoryFake(IUnitOfWork uow) : base(uow)
        {
        }

        public List<Event> GetAll()
        {
            var eventList = GetAllInMemory();
            return eventList;
        }

        public override Event GetById(string id)
        {
            var idGuid = new Guid(id);

            return GetAllInMemory().FirstOrDefault(x => x.Id == idGuid);
        }

        private List<Event> GetAllInMemory()
        {
            var list = new List<Event>();

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActivePeriod = DateTimeRange.CreateOneWeekRange(DateTime.Today),
                Name = "Event Demo 1",
                Summary = "Summary demo 1",
                Description = "Description demo 1",
                EventDate = DateTime.Today.AddDays(10),
                Price = 0,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna"                
            });

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActivePeriod = DateTimeRange.CreateOneWeekRange(DateTime.Today),
                Name = "Event Demo 2",
                Summary = "Summary demo 2",
                Description = "Description demo 2",
                EventDate = DateTime.Today.AddDays(10),
                Price = 0,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna"
            });

            // TODO: complete all fields and add more demo events.

            return list;
        }
    }
}
