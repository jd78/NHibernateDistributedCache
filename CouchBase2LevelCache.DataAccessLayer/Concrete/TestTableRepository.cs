using System.Linq;
using CouchBase2LevelCache.DataAccessLayer.Interfaces;
using CouchBase2LevelCache.Model;
using NHibernate.Linq;

namespace CouchBase2LevelCache.DataAccessLayer.Concrete
{
    public class TestTableRepository : ITestTableRepository
    {
        private readonly ISessionManager _sessionManager;

        public TestTableRepository(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public void Save(TestTable test)
        {
            _sessionManager.Session.Save(test);
            _sessionManager.Session.Flush();
        }

        public void Update(TestTable test)
        {
            _sessionManager.Session.Update(test);
            _sessionManager.Session.Flush();
        }

        public TestTable GetById(int id)
        {
            return _sessionManager.Session.Get<TestTable>(id);
        }

        public System.Collections.Generic.IEnumerable<TestTable> GetAll()
        {
            return _sessionManager.Session.Query<TestTable>().Cacheable().ToList();
        }
    }
}
