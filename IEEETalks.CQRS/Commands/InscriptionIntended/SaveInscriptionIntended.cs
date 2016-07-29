using IEEETalks.Core.Entities;
using MediatR;

namespace IEEETalks.CQRS.Commands
{
    public class SaveInscriptionIntended : IRequest
    {
        public InscriptionIntended InscriptionIntended { get; }

        public SaveInscriptionIntended(InscriptionIntended inscriptionIntended)
        {
            InscriptionIntended = inscriptionIntended;
        }
    }
}
