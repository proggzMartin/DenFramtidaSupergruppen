using Destination_Lajet.Data;
using Microsoft.EntityFrameworkCore;

namespace Lajet.Tests
{
    public static class TestHelp
    {
        public static LajetContext CreateInMemLajetContext()
        {
            var dbOptions = new DbContextOptionsBuilder<LajetContext>()
                   .UseInMemoryDatabase(databaseName: "Test")
                   .Options;

            return new LajetContext(dbOptions);
        }
    }
}
