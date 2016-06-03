using IEEETalks.Common;
using IEEETalks.Core.Entities;

namespace IEEETalks.Data.Repositories.Interfaces
{
    public interface IEventRepository : IBaseRespository<Event>
    {
        ListResponse<Event> GetAll();
    }
}