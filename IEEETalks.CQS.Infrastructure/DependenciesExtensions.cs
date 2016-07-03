using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            currentContainer.Register<AbstractValidator<SaveInscriptionIntended>, SaveInscriptionIntendedValidator>();
        }

        public static void RegisterCQSCommandHandlers(this IContainer currentContainer)
        {
            currentContainer.Register<ICommandHandler<SaveInscriptionIntended>, SaveInscriptionIntendedHandler>();
        }

        public static void RegisterCQSSessionAndCommandBus(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, Session>();
            currentContainer.Register<ICommandBus, CommandBus>();
        }
    }
}
