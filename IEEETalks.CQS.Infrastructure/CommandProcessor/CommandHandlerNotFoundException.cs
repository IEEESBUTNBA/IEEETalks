using System;

namespace IEEETalks.CQS.Infrastructure.CommandProcessor
{
    public class CommandHandlerNotFoundException : Exception
    {
        public CommandHandlerNotFoundException(Type type)
            : base($"Command handler not found for command type: {type}")
        {
        }
    }
}