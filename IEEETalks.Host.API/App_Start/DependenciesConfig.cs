using IEEETalks.Common.IoC;
using IEEETalks.CQS.Infrastructure;
using IEEETalks.Persistance;

namespace IEEETalks.Host.API
{
    public class DependenciesConfig
    {
        public static void RegisterAll()
        {
            Container.Current.RegisterPersistanceInMemory();

            Container.Current.RegisterCQS();
        }
    }
}
