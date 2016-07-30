using System;
using System.Linq;
using FluentValidation;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;
using IEEETalks.Persistance;

namespace IEEETalks.CQRS.Commands
{
    public class SaveInscriptionIntendedValidator : AbstractValidator<SaveInscriptionIntended>
    {
        private readonly ISession _session;

        public SaveInscriptionIntendedValidator(ISession session)
        {
            _session = session;
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            RuleFor(p => p.InscriptionIntended)
                .NotNull()
                .WithMessage("The inscription intended is invalid.");
            RuleFor(p => p.InscriptionIntended)
                .SetValidator(new InscriptionIntendedValidator(_session))
                .When(p => p.InscriptionIntended != null);
            RuleFor(p => p.InscriptionIntended)
                .NotEmpty()
                .Must(NotBeenInscribed)
                .WithMessage("You are already  signed up for  this event.")
                .When(p => p.InscriptionIntended != null);
        }

        private bool NotBeenInscribed(InscriptionIntended inscriptionIntended)
        {
            var result = this._session.GetQueryable<InscriptionIntended>()
                        .Any(x =>
                            x.Email.ToLower() == inscriptionIntended.Email &&
                            x.EventId == inscriptionIntended.EventId
                        );

            return !result;
        }
    }

    public class InscriptionIntendedValidator : AbstractValidator<InscriptionIntended>
    {
        private readonly ISession _session;

        public InscriptionIntendedValidator(ISession session)
        {
            _session = session;
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .EmailAddress();
            RuleFor(p => p.FirstName)
                .NotEmpty();
            RuleFor(p => p.LastName)
                .NotEmpty();
            RuleFor(p => p.EventId)
                .NotEmpty()
                .Must(ExistAndBeActiveEvent)
                .WithMessage("The event does not exist or is not active.");
        }

        private bool ExistAndBeActiveEvent(Guid eventId)
        {
            var today = DateTime.Now;

            var result = _session.GetQueryable<Event>()
                        .Any(x =>
                            x.Id == eventId &&
                            x.EventState == EventState.Active &&
                            x.ActiveSinceDate <= today &&
                            x.ActiveUntilDate >= today
                        );

            return result;
        }
    }
}
