using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
        public Property Property { get; set; }
        public int PropertyId { get; set; }
        public Client Client { get; set; }
        public int ClientId { get; set; }

    }
}