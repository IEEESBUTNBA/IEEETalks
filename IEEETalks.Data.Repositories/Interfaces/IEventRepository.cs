using System.Collections.Generic;
using IEEETalks.Core.Entities;

namespace IEEETalks.Data.Repositories.Interfaces
{
    public interface IEventRepository : IBaseRespository<Event>
    {
        List<Event> GetAll();
    }
}