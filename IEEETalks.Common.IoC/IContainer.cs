using System;

namespace IEEETalks.Common.IoC
{
    public interface IContainer
    {
        void Register<TInterface, TImplementation>() where TImplementation : TInterface;
        void RegisterSingleton<TInterface, TImplementation>() where TImplementation : TInterface;
        void Register<TInterface>(TInterface implementation) where TInterface : class;
        bool HasImplementationsFor<TImplementation>();
        TInterface Resolve<TInterface>();
        TInterface ResolveWithArguments<TInterface>(CtorArgs arguments);
    }
}
