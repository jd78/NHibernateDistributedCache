using System;
using NHibernate;

namespace CouchBase2LevelCache.DataAccessLayer.Interfaces
{
    public interface ISessionManager : IDisposable
    {
        ISession Session { get; }
    }
}
