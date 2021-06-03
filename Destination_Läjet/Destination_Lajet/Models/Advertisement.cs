using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Destination_Lajet.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }




        //REMOVE THIS BELOW LATER
        public string Place { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int SpotsAvailable { get; set; }
        [InverseProperty("JoinedEvents")]
        public List<User> Attendees { get; set; }
        [InverseProperty("HostedEvents")]
        public User Organizer { get; set; }
    }
}
