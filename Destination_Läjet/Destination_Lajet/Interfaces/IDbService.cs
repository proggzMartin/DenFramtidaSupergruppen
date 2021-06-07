using Destination_Lajet.Models;
using System.Collections.Generic;

namespace Destination_Lajet.Interfaces
{
    public interface IDbService
    {
        void AddAd(Ad ad, int companyId);
        void AddNewCompany(Company company);
        void AddUser(User user, int companyId);
        IEnumerable<Company> GetAllCompanies(bool tracking = false);
        Company GetCompany(int id, bool tracking = false);
        Ad GetAd(int id, bool tracking = false);
        User GetUser(string id, bool tracking = false);
        void RemoveAd(int userId);
        void RemoveCompany(int companyId); //removes all advertisements and users.
        void RemoveUser(string userId); 
    }
}
