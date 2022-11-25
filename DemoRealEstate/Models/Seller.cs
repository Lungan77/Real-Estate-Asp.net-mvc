using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Seller")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string AgentUserId { get; set; }
    }
}