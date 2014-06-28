using System;
using CouchBase2LevelCache.DataAccessLayer.Interfaces;
using NHibernate;

namespace CouchBase2LevelCache.DataAccessLayer.Concrete
{
    public class SessionManager : ISessionManager
    {
        public ISession Session { get; private set; }

        public SessionManager(ISessionFactoryManager sessionFactoryManager)
        {
            Session = sessionFactoryManager.SessionFactory.OpenSession();
            Session.BeginTransaction();
        }

        public void Dispose()
        {
            Session.Transaction.Commit();
            Session.Clear();
            GC.SuppressFinalize(this);
        }
    }
}
