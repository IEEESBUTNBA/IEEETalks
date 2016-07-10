using System;
using System.Linq;

namespace IEEETalks.Persistance
{
    public interface ISession
    {
        void Store<T>(string id, T item);
        void Store<T>(Guid id, T item);
        void Remove<T>(string id);
        void Remove<T>(Guid id);
        T GetById<T>(string id);
        T GetById<T>(Guid id);
        IQueryable<T> GetQueryable<T>();

        //TOutput Aggregate<T, TOutput>(IEnumerable<BsonDocument> pipeline);
    }
}
