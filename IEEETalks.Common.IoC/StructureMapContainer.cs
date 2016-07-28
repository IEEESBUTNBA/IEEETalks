using System;

namespace IEEETalks.Common.IoC
{
    internal class StructureMapContainer : IContainer
    {
        private readonly StructureMap.Container _container = new StructureMap.Container();

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _container.Configure(x => x.For<TInterface>().Use<TImplementation>());
        }

        public void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface
        {
            _container.Configure(x => x.For<TInterface>().Singleton().Use<TImplementation>());
        }

        public void Register<TInterface>(TInterface implementation) where TInterface : class
        {
            _container.Inject(implementation);
        }

        public TInterface Resolve<TInterface>()
        {
            try
            {
                return _container.GetInstance<TInterface>();
            }
            catch (Exception ex)
            {
                throw new ContainerException(ex);
            }
        }

        public TInterface ResolveWithArguments<TInterface>(CtorArgs arguments)
        {
            try
            {
                return _container.GetInstance<TInterface>(new StructureMap.Pipeline.ExplicitArguments(arguments));
            }
            catch (Exception ex)
            {
                throw new ContainerException(ex);
            }
        }

        public bool HasImplementationsFor<TImplementation>()
        {
            return _container.Model.HasImplementationsFor<TImplementation>();
        }
    }
}
