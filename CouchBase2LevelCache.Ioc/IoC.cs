using Autofac;
using CouchBase2LevelCache.DataAccessLayer.Concrete;
using CouchBase2LevelCache.DataAccessLayer.Interfaces;

namespace CouchBase2LevelCache.Ioc
{
    public static class IoC
    {
        public static IContainer Container { get; private set; }

        public static void InstantiateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SessionFactoryManager>().As<ISessionFactoryManager>().SingleInstance();
            builder.RegisterType<SessionManager>().As<ISessionManager>();
            builder.RegisterType<TestTableRepository>().As<ITestTableRepository>();
            Container = builder.Build();
        }
    }
}
