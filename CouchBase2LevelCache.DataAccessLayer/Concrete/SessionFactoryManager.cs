using CouchBase2LevelCache.DataAccessLayer.Interfaces;
using CouchBase2LevelCache.Model;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using NHibernate.Caches.Couchbase;

namespace CouchBase2LevelCache.DataAccessLayer.Concrete
{
    public class SessionFactoryManager : ISessionFactoryManager
    {
        public ISessionFactory SessionFactory { get; private set; }

        public SessionFactoryManager()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

               IPersistenceConfigurer config = MsSqlConfiguration
                .MsSql2008
                .ConnectionString(connectionString)
                .ShowSql();

            SessionFactory = Fluently.Configure()
                .Database(config)
                .Cache(c => c.ProviderClass<CouchbaseCacheProvider>().UseQueryCache())
                .Mappings(m => m.AutoMappings
                    .Add(AutoMap.AssemblyOf<IEntity>()
                        .Conventions.Add(DefaultCascade.All())
                        .UseOverridesFromAssemblyOf<TestTableMap>
                    )).BuildSessionFactory();
        }
    }
}
