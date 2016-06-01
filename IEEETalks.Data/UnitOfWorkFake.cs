namespace IEEETalks.Data
{
    public class UnitOfWorkFake : IUnitOfWork
    {
        public IDocumentSession Session { get; set; }

        public void Dispose()
        {
        }

        public void Commit()
        {
        }
    }
}
