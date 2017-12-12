using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Realt.Models
{
    public class SearchAdvertisementModel
    {
        public string Location { get; set; }
        public float MinSize { get; set; }
        public float MaxSize { get; set; }
        public float MinCost { get; set; }
        public float MaxCost { get; set; }
    }
}