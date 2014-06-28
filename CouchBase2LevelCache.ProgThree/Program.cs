using System;
using System.Threading;
using Autofac;
using CouchBase2LevelCache.DataAccessLayer.Interfaces;
using CouchBase2LevelCache.Ioc;

namespace CouchBase2LevelCache.ProgThree
{
    class Program
    {
        static void Main(string[] args)
        {
            IoC.InstantiateContainer();
            while (true)
            {
                using (var scope = IoC.Container.BeginLifetimeScope())
                {
                    var repo = scope.Resolve<ITestTableRepository>();
                    var test = repo.GetById(1);
                    test.Description = Guid.NewGuid().ToString();
                    repo.Update(test);
                }
                Console.WriteLine("Updated");
                Thread.Sleep(10000);
            }
        }
    }
}
