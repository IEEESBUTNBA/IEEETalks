using FluentValidation.Results;

namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public interface ICommandBus
    {
        ICommandResult Submit<TCommand>(TCommand command) where TCommand : ICommand;
        ValidationResult Validate<TCommand>(TCommand command) where TCommand : ICommand;
    }
}