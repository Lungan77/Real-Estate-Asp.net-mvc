using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Property
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Name of property")]
        public string PropertyName { get; set; }

        [Required]  
        [Display(Name = "Type of Property")]
        public string PropertyType { get; set; }

        [Required]
        public string Province { get; set; }

        [Required]
        [Display(Name = "City or Suburb")]
        public string CityorSuburb { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Address { get; set; }

        [Display(Name = "Agent Name")]
        public string AgentName { get; set; }
        public string AgentId { get; set; }
        public double Price { get; set; }
        [Display(Name = "Agent Share R")]
        public int Agent_share { get; set; }
       
        [Display(Name = "Property details")]
        public string PropertyInf { get; set; }

        [Display(Name = "Agent Phone-number")]
        public string AgentPhoneNumber { get; set; }
        public bool Sold { get; set; }
        public Seller Seller { get; set; }
        public int Balance { get; set; }
        public int ClientId { get; set; }
        [Display(Name = "Select a seller")]
        public int SellerId { get; set; }
        [Url]
        public string ImageURL { get; set; }
        [Url]
        public string ImageURL1 { get; set; }
        [Url]
        public string ImageURL2 { get; set; }
        [Url]
        public string ImageURL3 { get; set; }
    }
}