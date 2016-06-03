namespace IEEETalks.Data
{
    public interface IDocumentSession
    {
        void Delete<T>(T entity);
        T Load<T>(string id);
        void Store<T>(T entity);
    }
}
