using System.Collections.Generic;

namespace IEEETalks.Data.Repositories.Interfaces
{
    public interface IBaseRespository<T> where T : class
    {
        void Store(T entity);
        void StoreMany(List<T> entities);
        void Delete(T entity);
        void DeleteMany(List<T> entities);
        T GetById(string id);
    }
}