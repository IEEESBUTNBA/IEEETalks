using System.Collections.Generic;
using IEEETalks.Core.Entities;

namespace IEEETalks.Data.Repositories.Repositories.EventRepository
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        List<Event> GetAllEvents();
    }
}