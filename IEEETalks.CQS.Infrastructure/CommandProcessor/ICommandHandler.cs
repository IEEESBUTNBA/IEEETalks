namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}