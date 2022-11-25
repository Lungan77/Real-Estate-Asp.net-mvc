using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Buyer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Buyer")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public string AgentUserId { get; set; }
    }
}