using Microsoft.AspNetCore.Identity;

namespace Destination_Lajet.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
    }
}
