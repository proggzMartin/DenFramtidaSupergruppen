using Destination_Lajet.Data;
using Destination_Lajet.Exceptions;
using Destination_Lajet.Interfaces;
using Destination_Lajet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Destination_Lajet.Services
{
    public class DbService : IDbService
    {
        private readonly LajetContext _db;

        public DbService(LajetContext db)
        {
            if (db == null)
                throw new ArgumentNullException("No db via DI.");
            _db = db;
        }

        public void AddAd(Ad ad, int companyId)
        {
            var c = GetCompany(companyId, true);
            if (c == null)
                throw new DbException("Company not found.");

            c.Ads.Add(ad);
            _db.SaveChanges();
        }

        public void AddNewCompany(Company company)
        {
            _db.Company.Add(company);
            _db.SaveChanges();
        }

        public void AddUser(User user, int companyId)
        {
            var c = GetCompany(companyId, true);
            c.Users.Add(user);
            _db.SaveChanges();
        }

        public Ad GetAd(int id, bool tracking = false)
        {
            return tracking ? _db.Ad.FirstOrDefault(x => x.Id.Equals(id)) :
                              _db.Ad.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }


        public IEnumerable<Company> GetAllCompanies(bool tracking = false)
        {
            return tracking ? _db.Company :
                              _db.Company.AsNoTracking();
        }

        public Company GetCompany(int id, bool tracking = false)
        {
            return tracking ? _db.Company.FirstOrDefault(x => x.Id.Equals(id)) : 
                              _db.Company.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public User GetUser(int id, bool tracking = false)
        {
            return tracking ? _db.User.FirstOrDefault(x => x.Id.Equals(id)) :
                              _db.User.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void RemoveAd(int id)
        {
            _db.Ad.Remove(GetAd(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// Removing a company removes associated users and Ads.
        /// </summary>
        /// <param name="id"></param>
        public void RemoveCompany(int id)
        {
            var c = _db.Company
                        .Include(x => x.Ads)
                        .Include(x => x.Users);
        }

        public void RemoveUser(int id)
        {
            _db.User.Remove(GetUser(id));
            _db.SaveChanges();
        }
    }
}
