using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data
{
    public interface IUnitOfWork
    {
        void Delete<T>(T entity);
        T Load<T>(string id);
        void Store<T>(T entity);
        void Commit();
    }
}
