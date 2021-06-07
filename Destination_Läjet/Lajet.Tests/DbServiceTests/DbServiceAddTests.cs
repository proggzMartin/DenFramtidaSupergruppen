using Destination_Lajet.Exceptions;
using Destination_Lajet.Models;
using System.Linq;
using Xunit;
using static Lajet.Tests.DbServiceTests.DbServiceTestHelp;

namespace Lajet.Tests.DbServiceTests.AddTests
{
    public class DbServiceAddTests
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

                sut.AddAd(a1, cId1);
                sut.AddAd(a2, cId1);
                sut.AddAd(a3, cId2); //other company

                var cnew = sut.GetCompany(cId1);

                Assert.NotNull(cnew.Ads);
                Assert.NotEmpty(cnew.Ads);
                Assert.Contains(a1.Id, cnew.Ads.Select(x => x.Id));
                Assert.Contains(a2.Id, cnew.Ads.Select(x => x.Id));
                Assert.DoesNotContain(a3.Id, cnew.Ads.Select(x => x.Id));
            });
        }

        [Fact]
        public  void AddNewCompany_ShouldAdd()
        {
            var cname = "c1";
            var c = new Company() { Name = cname };

            PerformDbServiceActions((sut, db) => {
                sut.AddNewCompany(c);
                var cget = sut.GetCompany(c.Id);

                Assert.Equal(cget.Id, c.Id);
                Assert.Equal(c.Name, cget.Name);
            });
        }

        [Fact]
        public void AddUser_ShouldAdd()
        {
            var uname = "userName";
            var u = new User() { FirstName = uname };

            var cname = "cname";
            var c = new Company() { Name = cname };

            PerformDbServiceActions((sut, db) => {
                sut.AddNewCompany(c);

                sut.AddUser(u, c.Id);
                var uget = sut.GetUser(u.Id);

                Assert.Equal(u.Id, uget.Id);
                Assert.Equal(u.FirstName, uget.FirstName);
            });
        }
    }
}
