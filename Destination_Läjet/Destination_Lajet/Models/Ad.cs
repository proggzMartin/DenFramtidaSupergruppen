
using System;

namespace Destination_Lajet.Models
{
    public class Ad //Short for advertisement.
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public string Business { get; set; }
        public int Claims { get; set; }
        public int CompanyId { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
