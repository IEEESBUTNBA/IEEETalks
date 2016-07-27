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
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?",
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
                Description = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate",
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
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
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
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum",
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
