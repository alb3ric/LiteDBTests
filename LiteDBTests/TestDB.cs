using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteDBTests
{
    static class TestDB
    {

        private static readonly Lazy<LiteRepository> _repository
            = new Lazy<LiteRepository>(() =>
            {
                string databasePath = @"testlitedb.db";
                var res = new LiteRepository(new LiteDatabase(new ConnectionString() { Filename = databasePath, Connection = ConnectionType.Direct, Upgrade = false }));
                res.EnsureIndex<Entity>(nameof(Entity.Name));
                res.EnsureIndex<Entity>(nameof(Entity.FirstName));
                res.EnsureIndex<Entity>(nameof(Entity.Age));
                return res;
            });

        public static LiteRepository Repository => _repository.Value;

        public static void Load()
        {
            var dummy = _repository.Value;
        }

        public static void DisposeInstance()
        {
            if (_repository.IsValueCreated)
                _repository.Value.Dispose();
        }


    }
}
