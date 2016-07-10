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

        public void Register<TInterface>(TInterface implementation) where TInterface : class, IDisposable
        {
            _container.Inject(implementation);
            //container.Configure(x => x.For<TInterface>().Use(() => implementation));
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

        //public TInterface ResolveWithArguments<TInterface>(params object[] arguments)
        //{
        //    try
        //    {
        //        var kernelTarget = container.TryGetInstance<TInterface>();

        //        Type implementationType = (Type)kernelTarget.GetType().GetField("prototype").GetValue(kernelTarget);
        //        var constructor = implementationType.GetConstructor(arguments.Select(arg => arg.GetType()).ToArray());

        //        var constructorArguments = new StructureMap.Pipeline.ExplicitArguments();
        //        int i = 0;
        //        foreach (var parameter in constructor.GetParameters())
        //        {
        //            constructorArguments.SetArg(parameter.Name, arguments[i++]);
        //        }

        //        return container.GetInstance<TInterface>(constructorArguments);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ContainerException(ex);
        //    }
        //}

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

        public TInterface Inject<TInterface>(TInterface toInject) where TInterface : class
        {
            _container.Inject(toInject);
            return toInject;
        }


        public bool HasImplementationsFor<TImplementation>()
        {
            return _container.Model.HasImplementationsFor<TImplementation>();
        }
    }
}
