using Destination_Lajet.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Lajet.Tests.DbServiceTests.DbServiceTestHelp;

namespace Lajet.Tests.DbServiceTests.GetTests
{
    public class DbServiceGetTests
    {
        [Fact]
        public void GetAllCompanies_ShouldGet()
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
                db.DetachAll();
            });
        }

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

                var gottenCompany = sut.GetCompany(cId1);
                Assert.Equal(cId1, gottenCompany.Id);

                var gottenCompany2 = sut.GetCompany(cId2);
                Assert.Equal(cId2, gottenCompany2.Id);
                db.DetachAll();
            });
        }

        [Fact]
        public void GetCompany_NoCopmanyAtId_ShouldGetNull()
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

                var gottenCompany = sut.GetCompany(3);
                Assert.Null(gottenCompany);
                db.DetachAll();
            });
        }

        [Fact]
        public void GetAd_ShouldGetAd()
        {
            PerformDbServiceActions((sut, db) => {
                int adId1 = 1, adId2 = 2;
                var a1 = new Ad() { Id = adId1 };
                var a2 = new Ad() { Id = adId2 };

                var ads = new List<Ad>() {
                    a1, a2
                };
                db.Ad.AddRange(ads);
                db.SaveChanges();

                var gottenAd1 = sut.GetAd(adId1);
                Assert.Equal(adId1, gottenAd1.Id);

                var gottenAd2 = sut.GetAd(adId2);
                Assert.Equal(adId2, gottenAd2.Id);
                db.DetachAll();
            });
        }

        [Fact]
        public void GetUser_ShouldGetUser()
        {
            PerformDbServiceActions((sut, db) => {
                string userId1 = "user1", userId2 = "user2";
                var user1 = new User() { Id = userId1 };
                var user2 = new User() { Id = userId2 };

                var users = new List<User>() {
                    user1, user2
                };
                db.User.AddRange(users);
                db.SaveChanges();

                var gottenUser1 = sut.GetUser(userId1);
                Assert.Equal(userId1, gottenUser1.Id);

                var gottenUser2 = sut.GetUser(userId2);
                Assert.Equal(userId2, gottenUser2.Id);
                db.DetachAll();
            });
        }
    }
}
