using IEEETalks.Common.IoC;

namespace IEEETalks.Persistance
{
    public static class DependenciesExtensions
    {
        public static void RegisterPersistanceInMongoDb(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, MongoDbSession>();
        }

        public static void RegisterPersistanceInMemory(this IContainer currentContainer)
        {
            currentContainer.Register<ISession, InMemorySession>();
        }
    }
}
