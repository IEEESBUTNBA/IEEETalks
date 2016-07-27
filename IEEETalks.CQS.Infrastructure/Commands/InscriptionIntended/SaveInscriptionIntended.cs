using IEEETalks.Core.Entities;
using IEEETalks.CQS.Infrastructure.CommandProcessor;

namespace IEEETalks.CQS.Infrastructure.Commands
{
    public class SaveInscriptionIntended : ICommand
    {
        public InscriptionIntended InscriptionIntended { get; }

        public SaveInscriptionIntended(InscriptionIntended inscriptionIntended)
        {
            InscriptionIntended = inscriptionIntended;
        }
    }
}
