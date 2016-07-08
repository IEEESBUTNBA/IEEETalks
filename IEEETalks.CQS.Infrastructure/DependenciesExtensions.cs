using FluentValidation;
using IEEETalks.Common.IoC;
using IEEETalks.CQS.Infrastructure.CommandProcessor;
using IEEETalks.CQS.Infrastructure.Commands;

namespace IEEETalks.CQS.Infrastructure
{
    public static class DependenciesExtensions
    {
        public static void RegisterCQSAll(this IContainer currentContainer)
        {
            currentContainer.RegisterCQSValidators();
            currentContainer.RegisterCQSCommandHandlers();
            currentContainer.RegisterCQSSessionAndCommandBus();
        }

        public static void RegisterCQSValidators(this IContainer currentContainer)
        {
            currentContainer.RegisterSingleton<AbstractValidator<SaveInscriptionIntended>, SaveInscriptionIntendedValidator>();
        }

        public static void RegisterCQSCommandHandlers(this IContainer currentContainer)
        {
            currentContainer.RegisterSingleton<ICommandHandler<SaveInscriptionIntended>, SaveInscriptionIntendedHandler>();
        }

        public static void RegisterCQSSessionAndCommandBus(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, SessionMock>();
            currentContainer.RegisterSingleton<ICommandBus, CommandBus>();
        }
    }
}
