using NHibernate;

namespace CouchBase2LevelCache.DataAccessLayer.Interfaces
{
    public interface ISessionFactoryManager
    {
        ISessionFactory SessionFactory { get; }
    }
}
