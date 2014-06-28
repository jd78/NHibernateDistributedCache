using System;
using System.Threading;
using Autofac;
using CouchBase2LevelCache.DataAccessLayer.Interfaces;
using CouchBase2LevelCache.Ioc;

namespace CouchBase2LevelCache.ProgTwo
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
                    var t = repo.GetById(1);
                    Console.WriteLine(t.Description);
                    Console.WriteLine("Calling GetAll");
                    repo.GetAll();
                    Console.WriteLine("GetAll called");
                }
                Thread.Sleep(2000);
            }
        }
    }
}
