using System;
using System.Linq;

namespace IEEETalks.CQS.Infrastructure
{
    public interface ISession
    {
        void Store<T>(string id, T item);
        void Store<T>(Guid id, T item);
        void Remove<T>(string id);
        IQueryable<T> GetQueryable<T>();

        //TOutput Aggregate<T, TOutput>(IEnumerable<BsonDocument> pipeline);
    }
}
