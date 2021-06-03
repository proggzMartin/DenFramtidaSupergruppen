using Destination_Lajet.Data;
using Destination_Lajet.Services;
using System;

namespace Lajet.Tests.DbServiceTests
{
    public class DbServiceTestHelp
    {
        public static void PerformDbServiceActions(Action<DbService, LajetContext> test)
        {
            using var db = TestHelp.CreateInMemLajetContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var service = new DbService(db);
            test.Invoke(service, db);
        }
    }
}
