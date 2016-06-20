using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEEETalks.Data.Repositories.Impl
{
    public class InscripcionIntendedRepositoryFake : IInscriptionIntended
    {
        private static List<InscriptionIntended> _internalInscriptionIntendedList;

        private IUnitOfWork uow { get; set; }

        public InscripcionIntendedRepositoryFake(IUnitOfWork uow)
        {
            if (_internalInscriptionIntendedList == null)
                _internalInscriptionIntendedList = GetAllInMemory();
            this.uow = uow;
        }

        public ListResponse<InscriptionIntended> GetByEventId(int id)
        {
            var result = (from x in _internalInscriptionIntendedList
                          where x.EventId.Equals(id) select x).ToList();
            return (new ListResponse<InscriptionIntended> {Items=result, TotalRecords=result.Count});
        }

        public InscriptionIntended GetById(string id)
        {
            InscriptionIntended result = (from x in _internalInscriptionIntendedList
                          where x.Id.Equals(id)
                          select x).First();
            return result;
        }

        public void Store(InscriptionIntended entity)
        {
            uow.Session.Store(entity);
        }

        private List<InscriptionIntended> GetAllInMemory()
        {
            var list = new List<InscriptionIntended>();

            list.Add(new InscriptionIntended()
            {
                Id = Guid.NewGuid(),
                FirstName = "Dana",
                LastName = "Luz",
                Email = "dana.luz@hotmail.com.ar",
                EventId = (new EventRepositoryFake(null).GetAll().Items.First().Id) 
                });
            return list;
        }
    }
}
