using IEEETalks.Common;
using IEEETalks.Core.Entities;

namespace IEEETalks.Data.Repositories.Interfaces
{
    public interface IInscriptionIntended
    {
        ListResponse<InscriptionIntended> GetByEventId(int id);

        void Store(InscriptionIntended entity);
        InscriptionIntended GetById(string id);
    }
}
