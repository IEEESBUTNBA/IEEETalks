using IEEETalks.Common.IoC;
using IEEETalks.CQS.Infrastructure;

namespace IEEETalks.Host.API
{
    public class DependenciesConfig
    {
        public static void RegisterAll()
        {
            Container.Current.RegisterCQSAll();
        }
    }
}
