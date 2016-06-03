using System;

namespace IEEETalks.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IDocumentSession Session { get; set; }
        void Commit();
    }
}
