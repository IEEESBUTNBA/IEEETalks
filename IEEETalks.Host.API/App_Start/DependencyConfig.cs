using IEEETalks.Common.IoC;
using IEEETalks.Data;
using IEEETalks.Data.Repositories.Impl;
using IEEETalks.Data.Repositories.Interfaces;

namespace IEEETalks.Host.API
{
    public class DependencyConfig
    {
        public static void RegisterAll()
        {
            Container.Current = new StructureMapContainer();

            Container.Current.Register<IUnitOfWork, UnitOfWorkFake>();
            Container.Current.Register<IEventRepository, EventRepositoryFake>();
            Container.Current.Register<IInscriptionIntended, InscripcionIntendedRepositoryFake>();
        }
    }
}
