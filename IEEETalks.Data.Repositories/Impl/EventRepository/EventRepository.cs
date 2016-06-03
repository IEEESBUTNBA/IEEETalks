using IEEETalks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data.Repositories.Repositories.EventRepository
{
    public class EventRepository : IBaseRepository<Event>, IEventRepository
    {
        public List<Event> GetAllEvents()
        {
            var eventList = new List<Event>();
            return eventList;
        }
    }
}
