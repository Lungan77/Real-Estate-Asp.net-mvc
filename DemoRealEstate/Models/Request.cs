using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoRealEstate.Models
{
    public class Request
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string User_id { get; set; }
        public Agent Agent { get; set; }
        public int AgentId { get; set; }
    }
}