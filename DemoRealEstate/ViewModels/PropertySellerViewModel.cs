using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DemoRealEstate.Models;

namespace DemoRealEstate.ViewModels
{
    public class PropertySellerViewModel
    {
        public Property Property { get; set; }
        public Seller Seller { get; set; }
    }
}