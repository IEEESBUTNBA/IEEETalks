using System;
using System.Linq;
using FluentValidation;
using IEEETalks.Core.Entities;
using IEEETalks.Core.Enums;
using IEEETalks.CQS.Infrastructure.CommandProcessor;

namespace IEEETalks.CQS.Infrastructure.Commands
{
    public class SaveInscriptionIntendedValidator : AbstractValidator<SaveInscriptionIntended>
    {
        private readonly ISession _session;

        public SaveInscriptionIntendedValidator(ISession session)
        {
            this._session = session;
            ConfigureValidation();
        }

        private void ConfigureValidation()
        {
            RuleFor(p => p.InscriptionIntended)
                .NotNull()
                .WithMessage("The inscription intended is invalid.");
            RuleFor(p => p.InscriptionIntended.Email)
                .NotEmpty()
                .EmailAddress()
                .When(p => p.InscriptionIntended != null);
            RuleFor(p => p.InscriptionIntended.FirstName)
                .NotEmpty()
                .When(p => p.InscriptionIntended != null);
            RuleFor(p => p.InscriptionIntended.LastName)
                .NotEmpty()
                .When(p => p.InscriptionIntended != null);
            RuleFor(p => p.InscriptionIntended.EventId)
                .NotEmpty()
                .Must(ExistAndBeActiveEvent)
                .WithMessage("The event does not exist or is not active.")
                .When(p => p.InscriptionIntended != null);
            RuleFor(p => p.InscriptionIntended)
                .NotEmpty()
                .Must(NotBeenInscribed)
                .WithMessage("You are already inscribed for this event.")
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

        private bool ExistAndBeActiveEvent(Guid eventId)
        {
            var today = DateTime.Now;

            var result = this._session.GetQueryable<Event>()
                        .Any(x =>
                            x.EventState == EventState.Active &&
                            x.ActiveStartDate >= today &&
                            x.ActiveEndDate <= today
                        );

            return result;
        }
    }
}
