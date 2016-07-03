using IEEETalks.Core.Entities;
using IEEETalks.CQS.Infrastructure.CommandProcessor;

namespace IEEETalks.CQS.Infrastructure.Commands
{
    public class SaveInscriptionIntendedHandler : ICommandHandler<SaveInscriptionIntended>
    {
        private readonly ISession _session;

        public SaveInscriptionIntendedHandler(ISession session)
        {
            this._session = session;
        }

        public void Execute(SaveInscriptionIntended command)
        {
            _session.Store(command.InscriptionIntended.Id, command.InscriptionIntended);
        }
    }
}
