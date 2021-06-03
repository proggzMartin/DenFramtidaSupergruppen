using Destination_Lajet.Exceptions;
using Destination_Lajet.Models;
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
            var cId = 1;
            var c = new Company() { Id = cId };
            var a1 = new Ad();
            var a2 = new Ad();

            PerformDbServiceActions((sut, db) => {
                sut.AddNewCompany(c);
                sut.AddAd(a1, cId);
                sut.AddAd(a2, cId);

                var cnew = sut.GetCompany(cId);

            });
        }
    }
}
