﻿using System.Collections.Generic;

namespace Destination_Lajet.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Ad> Ads { get; set; }
        public List<User> Users { get; set; }

    }
}
