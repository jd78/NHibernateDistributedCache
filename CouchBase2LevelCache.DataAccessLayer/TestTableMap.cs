using System;
using CouchBase2LevelCache.Model;
using FluentNHibernate.Automapping.Alterations;

namespace CouchBase2LevelCache.DataAccessLayer
{
    public class TestTableMap : IAutoMappingOverride<TestTable>
    {
        public void Override(FluentNHibernate.Automapping.AutoMapping<TestTable> mapping)
        {
            mapping.Id(p => p.Id).GeneratedBy.Native();
            mapping.Map(p => p.Description);

            mapping.Cache.NonStrictReadWrite();
        }
    }
}
