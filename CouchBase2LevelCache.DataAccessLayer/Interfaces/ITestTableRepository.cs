using System;
using System.Collections.Generic;
using CouchBase2LevelCache.Model;

namespace CouchBase2LevelCache.DataAccessLayer.Interfaces
{
    public interface ITestTableRepository
    {
        void Save(TestTable test);
        void Update(TestTable test);
        TestTable GetById(int id);
        IEnumerable<TestTable> GetAll();
    }
}