using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;

namespace IEEETalks.Persistance
{
    public class InMemorySession : ISession
    {
        private readonly string _boundedContext;
        private static Dictionary<string, List<dynamic>> _collections;

        public InMemorySession(string boundedContext = "IEEETalks-Default")
        {
            _boundedContext = boundedContext;
            if (_collections == null)
            {
                _collections = new Dictionary<string, List<dynamic>>
                {
                    {
                        typeof(Event).Name, GetAllInMemory().Cast<dynamic>().ToList()
                    },
                    {
                        typeof(InscriptionIntended).Name, (new List<InscriptionIntended>()).Cast<dynamic>().ToList()
                    }
                };
            }
        }

        public void Store<T>(string id, T item)
        {
            Store<T>(new Guid(id), item);
        }

        public void Store<T>(Guid id, T item)
        {
            var result = (from x in _collections[typeof(T).Name]
                          where x.Id == id
                          select x).FirstOrDefault();

            if (result != null)
                this.Remove<T>(result.Id);

            _collections[typeof(T).Name].Add(item);
        }

        public void Remove<T>(string id)
        {
            Remove<T>(new Guid(id));
        }

        public void Remove<T>(Guid id)
        {
            var result = (from x in _collections[typeof(T).Name]
                          where x.Id == id
                          select x).FirstOrDefault();

            if (result != null)
                _collections[typeof(T).Name].Remove(result);
        }

        public T GetById<T>(string id)
        {
            return GetById<T>(new Guid(id));
        }

        public T GetById<T>(Guid id)
        {
            var result = (from x in _collections[typeof(T).Name]
                          where x.Id == id
                          select x).FirstOrDefault();

            return result;
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
                Id = new Guid("20133f6d-5356-4ed2-b0fa-75dc73646499"),
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
                Id = new Guid("1aac76fb-eda5-41ba-9d2c-d12765b5067d"),
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
