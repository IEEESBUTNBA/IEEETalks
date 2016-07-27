using FluentValidation;
using FluentValidation.Results;
using IEEETalks.Common;
using IEEETalks.Common.IoC;

namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public class CommandBus : ICommandBus
    {
        public void Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = Container.Current.Resolve<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }

            var validationResult = this.Validate(command);

            Guard.ForValidationResult(validationResult);

            handler.Execute(command);
        }

        public ValidationResult Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = Container.Current.Resolve<AbstractValidator<TCommand>>();

            return handler != null ? handler.Validate(command) : new ValidationResult();
        }
    }
}