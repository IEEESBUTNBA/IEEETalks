using System;
using System.Collections.Generic;
using IEEETalks.Common;
using IEEETalks.Common.IoC;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;

namespace IEEETalks.Persistance
{
    public static class DependenciesExtensions
    {
        public static void RegisterPersistanceInMongoDb(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, MongoDbSession>();
        }

        public static void RegisterPersistanceInMemory(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, InMemorySession>();

            // TODO: remove the following code and references to core domain
            foreach (var evnt in GetAllInMemory())
            {
                currentContainer.Resolve<ISession>().Store(evnt.Id, evnt);
            }
            
        }

        private static List<Event> GetAllInMemory()
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
