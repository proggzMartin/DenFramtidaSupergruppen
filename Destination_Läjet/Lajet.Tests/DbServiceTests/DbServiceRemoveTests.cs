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

            PerformDbServiceActions((sut, db) => {
                sut.AddNewCompany(c);
                sut.AddAd(a, c.Id);
                
                var addedAdId = a.Id;

                sut.RemoveAd(a.Id);

                Assert.Null(sut.GetAd(addedAdId));
            });
        }
        //void RemoveCompany(int companyId); //removes all advertisements and users.
        //void RemoveUser(string userId);

    }
}
