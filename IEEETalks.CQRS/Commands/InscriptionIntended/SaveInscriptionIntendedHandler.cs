using IEEETalks.Persistance;
using MediatR;

namespace IEEETalks.CQRS.Commands
{
    public class SaveInscriptionIntendedHandler : RequestHandler<SaveInscriptionIntended>
    {
        private readonly ISession _session;

        public SaveInscriptionIntendedHandler(ISession session)
        {
            _session = session;
        }

        protected override void HandleCore(SaveInscriptionIntended message)
        {
            _session.Store(message.InscriptionIntended.Id, message.InscriptionIntended);
        }
    }
}
