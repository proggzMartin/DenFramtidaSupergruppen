using Destination_Lajet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using static Lajet.Tests.DbServiceTests.DbServiceTestHelp;

namespace Lajet.Tests.DbServiceTests
{
    public class DbServiceRemoveTests
    {
        [Fact]
        public void RemoveAd_ShouldRemove()
        {
            var a = new Ad()
            {
                Id = 1,
                Text = "hej"
            };
            var c = new Company() { Name = "c1" };

            PerformDbServiceActions(
                ActAndTest: (sut, db) => {
                    sut.AddNewCompany(c);
                    sut.AddAd(a, c.Id);
                
                    var addedAdId = a.Id;

                    db.DetachAll();

                    sut.RemoveAd(a.Id);
                    
                    Assert.Null(sut.GetAd(addedAdId));
            });
        }

        [Fact]
        public void RemoveCompany_ShouldRemoveCompanyAndAd()
        {
            var a = new Ad()
            {
                Id = 1,
                Text = "hej"
            };
            var c = new Company() { Name = "c1" };
            c.Ads = new List<Ad>() { a };

            PerformDbServiceActions(
                ActAndTest: (sut, db) => {
                    sut.AddNewCompany(c);
                    db.DetachAll();

                    sut.RemoveCompany(c.Id);

                    Assert.Null(sut.GetCompany(c.Id));
                    Assert.Null(sut.GetAd(a.Id));

                }
            );
        }

        [Fact]
        public void RemoveUser_ShouldRemove()
        {
            var u = new User()
            {
                FirstName = "hej"
            };

            PerformDbServiceActions(
                ActAndTest: (sut, db) => {
                    sut.AddUser(u);
                    db.DetachAll();

                    sut.RemoveUser(u.Id);

                    Assert.Null(sut.GetUser(u.Id));
                }
            );
        }
    }
}
