using Destination_Lajet.Exceptions;
using Destination_Lajet.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Lajet.Tests.DbServiceTests.DbServiceTestHelp;

namespace Lajet.Tests.DbServiceTests.GetTests
{
    public class DbServiceGetTests
    {

        //IEnumerable<Company> GetAllCompanies(bool tracking = false);
        //Company GetCompany(int id, bool tracking = false);
        //Ad GetAd(int id, bool tracking = false);
        //User GetUser(int id, bool tracking = false);

        [Fact]
        public void GetCompany_ShouldGet()
        {
            PerformDbServiceActions((sut, db) => {
                int cId1 = 1, cId2 = 2;
                var c1 = new Company() { Id = cId1 };
                var c2 = new Company() { Id = cId2 };

                var cs = new List<Company>() {
                    c1, c2
                };
                db.Company.AddRange(cs);
                db.SaveChanges();

                var allCs = sut.GetAllCompanies();

                Assert.Equal(2, allCs.Count());
                Assert.Equal(cId1, allCs.First().Id);
                Assert.Contains(c1, cs);
                Assert.Contains(c2, cs);
            });
        }
    }
}
