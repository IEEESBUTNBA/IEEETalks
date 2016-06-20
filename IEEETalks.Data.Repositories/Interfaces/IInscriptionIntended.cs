using IEEETalks.Common;
using IEEETalks.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data.Repositories.Interfaces
{
    public interface IInscriptionIntended
    {
        ListResponse<InscriptionIntended> GetByEventId(int id);

        void Store(InscriptionIntended entity);
        InscriptionIntended GetById(string id);
    }
}
