using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtApp.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Size { get; set; }
        public string Location { get; set; }
        public string Kind { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}