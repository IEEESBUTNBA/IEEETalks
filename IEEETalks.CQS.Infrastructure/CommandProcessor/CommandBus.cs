using FluentValidation;
using FluentValidation.Results;
using IEEETalks.Common.IoC;

namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public class CommandBus : ICommandBus
    {
        public ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = Container.Current.Resolve<ICommandHandler<TCommand>>();
            if (handler == null)
            {
                throw new CommandHandlerNotFoundException(typeof(TCommand));
            }
            var validationResult = this.Validate<TCommand>(command);
            if (validationResult.IsValid)
                handler.Execute(command);
            return new CommandResult(validationResult);
        }

        public ValidationResult Validate<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = Container.Current.Resolve<AbstractValidator<TCommand>>();
            if (handler != null)
            {
                return handler.Validate(command);
            }
            return new ValidationResult();
        }
    }
}