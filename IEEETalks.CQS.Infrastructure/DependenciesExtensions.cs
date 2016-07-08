using FluentValidation;
using IEEETalks.Common.IoC;
using IEEETalks.CQS.Infrastructure.CommandProcessor;
using IEEETalks.CQS.Infrastructure.Commands;

namespace IEEETalks.CQS.Infrastructure
{
    public static class DependenciesExtensions
    {
        public static void RegisterCQS(this IContainer currentContainer)
        {
            currentContainer.RegisterCQSValidators();
            currentContainer.RegisterCQSCommandHandlers();
            currentContainer.RegisterCQSCommandBus();
        }

        private static void RegisterCQSValidators(this IContainer currentContainer)
        {
            currentContainer.RegisterSingleton<AbstractValidator<SaveInscriptionIntended>, SaveInscriptionIntendedValidator>();
        }

        private static void RegisterCQSCommandHandlers(this IContainer currentContainer)
        {
            currentContainer.RegisterSingleton<ICommandHandler<SaveInscriptionIntended>, SaveInscriptionIntendedHandler>();
        }

        private static void RegisterCQSCommandBus(this IContainer currentContainer)
        {
            currentContainer.RegisterSingleton<ICommandBus, CommandBus>();
        }
    }
}
