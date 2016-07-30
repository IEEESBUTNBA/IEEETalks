using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using AutoMapper;
using FluentValidation;
using IEEETalks.Common;
using IEEETalks.CQRS;
using IEEETalks.Persistance;
using MediatR;
using StructureMap;

namespace IEEETalks.Host.API
{
    public class DependenciesConfig
    {
        public static void Register(HttpConfiguration config, out IApplicationSettings applicationSettings)
        {
            var container = new Container(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType<CQRSIndex>();
                    scanner.AssemblyContainingType<IMediator>();
                    scanner.WithDefaultConventions();
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(AbstractValidator<>));
                });
                cfg.For(typeof(IRequestHandler<,>)).DecorateAllWith(typeof(ValidatorHandler<,>));
                cfg.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
                cfg.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

                cfg.For<IMapper>().Singleton().Use(AutoMapperFactory.Create());

                cfg.For<ISession>().Singleton().Use<InMemorySession>();

                cfg.For<IApplicationSettings>().Singleton().Use<ApplicationSettings>();
                cfg.For<IGuard>().Singleton().Use<Guard>();
            });

            // TODO: review the following lines (alternatives?)
            #if DEBUG
                container.GetInstance<MockSessionDataInitializer>().Initialize();
            #endif

            applicationSettings = container.GetInstance<IApplicationSettings>();

            config.Services.Replace(typeof(IHttpControllerActivator), new StructureMapHttpControllerActivator(container));
        }

        private static class AutoMapperFactory
        {
            public static IMapper Create()
            {
                var config = new MapperConfiguration(Configure);

                return config.CreateMapper();
            }

            private static void Configure(IMapperConfigurationExpression cfg)
            {
                var profiles = Assembly.GetExecutingAssembly().GetTypes().Where(x => typeof(Profile).IsAssignableFrom(x));
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);
                }
            }
        }

        private class StructureMapHttpControllerActivator : IHttpControllerActivator
        {
            private readonly IContainer _container;

            public StructureMapHttpControllerActivator(IContainer container)
            {
                _container = container;
            }

            public IHttpController Create(
                    HttpRequestMessage request,
                    HttpControllerDescriptor controllerDescriptor,
                    Type controllerType)
            {
                return (IHttpController)_container.GetInstance(controllerType);
            }
        }
    }
}
