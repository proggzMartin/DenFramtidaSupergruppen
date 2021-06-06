using Destination_Lajet.Exceptions;
using Destination_Lajet.Models;
using System.Linq;
using Xunit;
using static Lajet.Tests.DbServiceTests.DbServiceTestHelp;
namespace Lajet.Tests.DbServiceTests
{
    public class DbServiceTests
    {
        [Fact]
        public void AddAd_NoCompany_ShouldThrow()
        {
            var a = new Ad()
            {
                Id = 1,
                Text = "hej"
            };

            PerformDbServiceActions((sut, db) => {
                Assert.Throws<DbException>(() => sut.AddAd(a, -1));
            });
        }

        [Fact]
        public void AddAd_HasCompany_ShouldWork()
        {
            int cId1 = 1, cId2 = 2;
            var c1 = new Company() { Id = cId1 };
            var c2 = new Company() { Id = cId2 };

            var a1 = new Ad() { Id = 1 };
            var a2 = new Ad() { Id = 2 };
            var a3 = new Ad() { Id = 3 };

            PerformDbServiceActions((sut, db) => {
                sut.AddNewCompany(c1);
                sut.AddNewCompany(c2);

                var addedAd1 = sut.AddAd(a1, cId1);
                var addedAd2 = sut.AddAd(a2, cId1);
                var addedAd3 = sut.AddAd(a3, cId2); //other company

                var cnew = sut.GetCompany(cId1);

                Assert.NotNull(cnew.Ads);
                Assert.NotEmpty(cnew.Ads);
                Assert.Contains(addedAd1.Id, cnew.Ads.Select(x => x.Id));
                Assert.Contains(addedAd2.Id, cnew.Ads.Select(x => x.Id));
                Assert.DoesNotContain(addedAd3.Id, cnew.Ads.Select(x => x.Id));
            });
        }
    }
}
