using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Collector
    {
        public int CodeCollector { get; set; }
        public string NameCollector { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
