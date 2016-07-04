using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;

namespace IEEETalks.CQS.Infrastructure
{
    public class SessionMock : ISession
    {
        private readonly string _boundedContext;
        private static Dictionary<string, List<object>> _collections;

        public SessionMock(string boundedContext = "IEEETalks-Default")
        {
            _boundedContext = boundedContext;
            _collections = new Dictionary<string, List<object>>
            {
                {
                    typeof(Event).Name, GetAllInMemory().Cast<object>().ToList()
                }
            };
        }

        public void Store<T>(string id, T item)
        {
            throw new NotImplementedException();
        }

        public void Store<T>(Guid id, T item)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(string id)
        {
            throw new NotImplementedException();
        }

        public void Remove<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(string id)
        {
            throw new NotImplementedException();
        }

        public T GetById<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetQueryable<T>()
        {
            return _collections[typeof(T).Name].Cast<T>().AsQueryable();
        }

        private List<Event> GetAllInMemory()
        {
            var list = new List<Event>();
            var activeRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5));

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
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                Name = "Event Demo 1",
                Summary = "Summary demo 1",
                Description = "Description demo 1",
                EventDates = eventDates,
                Price = 250,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna",
                Image = "../img/ieee[3].jpg"
            });

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                Name = "Event Demo 2",
                Summary = "Summary demo 2",
                Description = "Description demo 2",
                EventDates = eventDates,
                Price = 120,
                Quota = 100,
                EventState = EventState.Active,
                Location = "UTN.BA (Medrano 951) - Aula Magna",
                Image = "../img/14474300157302[1].jpg"
            });

            list.Add(new Event()
            {
                Id = Guid.NewGuid(),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
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
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
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
