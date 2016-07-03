using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;
using IEEETalks.Data.Repositories.Interfaces;
using IEEETalks.Data.Repositories.Shared;

namespace IEEETalks.Data.Repositories
{
    public class EventRepositoryFake : BaseRepository<Event>, IEventRepository
    {
        private static List<Event> _internalEventList;

        public EventRepositoryFake(IUnitOfWork uow) : base(uow)
        {
            if (_internalEventList == null)
                _internalEventList = GetAllInMemory();
        }

        public ListResponse<Event> GetAll()
        {
            var result = new ListResponse<Event>()
            {
                Items = _internalEventList,
                TotalRecords = _internalEventList.Count
            };

            return result;
        }

        public override Event GetById(string id)
        {
            var idGuid = new Guid(id);

            return _internalEventList.FirstOrDefault(x => x.Id == idGuid);
        }

        private List<Event> GetAllInMemory()
        {
            var list = new List<Event>();

            var eventDates = new List<EventDate>
            {
                new EventDate()
                {
                    Date = DateTime.Today,
                    StartAt = new TimeSpan(0, 10, 0, 0),
                    EndAt = new TimeSpan(0, 14, 0, 0)
                },
                new EventDate()
                {
                    Date = DateTime.Today.AddDays(1),
                    StartAt = new TimeSpan(0, 10, 0, 0),
                    EndAt = new TimeSpan(0, 14, 0, 0)
                },
            };

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveDateRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5)),
                Name = "Event Demo 1",
                Summary = "Summary demo 1",
                Description = "Description demo 1",
                EventDates = eventDates,
                Price = 250,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna" ,
                Image= "../img/ieee[3].jpg"
            });

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveDateRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5)),
                Name = "Event Demo 2",
                Summary = "Summary demo 2",
                Description = "Description demo 2",
                EventDates = eventDates,
                Price = 120,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna",
                Image= "../img/14474300157302[1].jpg"
            });

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveDateRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5)),
                Name = "Event Demo 3",
                Summary = "Summary demo 3",
                Description = "Description demo 3",
                EventDates = eventDates,
                Price = 100,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna",
                Image = "../img/ieee_ar_kite_azul_v[1].png"
            });
            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveDateRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5)),
                Name = "Event Demo 4",
                Summary = "Summary demo 4",
                Description = "Description demo 4",
                EventDates = eventDates,
                Price = 100,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna",
                Image = "../img/14474300157302[1].jpg"
            });

            return list;
        }
    }
}
