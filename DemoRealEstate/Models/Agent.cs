using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Agent
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Agent Share %")]
        [Range(0, 100)]
        public int Agent_share { get; set; }
    }
}