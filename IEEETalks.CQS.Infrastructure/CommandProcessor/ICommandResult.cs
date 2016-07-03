using FluentValidation.Results;

namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public interface ICommandResult
    {
        ValidationResult ValidationResult { get; }
        bool Success { get; }
    }
}
