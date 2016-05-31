using System.Collections.Generic;
using IEEETalks.Data.Repositories.Interfaces;

namespace IEEETalks.Data.Repositories.Shared
{
    public abstract class BaseRepository<T> : IBaseRespository<T> where T : class
    {
        protected IUnitOfWork uow;

        protected BaseRepository(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public virtual void Delete(T entity)
        {
            uow.Delete<T>(entity);
        }

        public virtual void DeleteMany(List<T> entities)
        {
            foreach (var entity in entities)
            {
                uow.Delete<T>(entity);
            }
        }

        public virtual T GetById(string id)
        {
            return uow.Load<T>(id);
        }

        public virtual void Store(T entity)
        {
            uow.Store(entity);
        }

        public virtual void StoreMany(List<T> entities)
        {
            foreach (var entity in entities)
            {
                uow.Store(entity);
            }
        }
    }
}
