using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realt.Models
{
    public class Advertisement
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public float Size { get; set; }
        public string Location { get; set; }
        public string Kind { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Date { get; set; }
    }
}