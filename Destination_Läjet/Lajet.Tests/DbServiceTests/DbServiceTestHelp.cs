using Destination_Lajet.Data;
using Destination_Lajet.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Lajet.Tests.DbServiceTests
{
    public static class DbServiceTestHelp
    {
        public static void PerformDbServiceActions(Action<DbService, LajetContext> ActAndTest)
        {
            using var db = TestHelp.CreateInMemLajetContext();

            db.Database.EnsureDeletedAsync();
            db.Database.EnsureCreatedAsync();
            var service = new DbService(db);
            ActAndTest.Invoke(service, db);
        }

        public static void DetachAll(this LajetContext db)
        {
            db.ChangeTracker.Entries().ToList().ForEach(x => x.State = EntityState.Detached);
        }
    }
}
