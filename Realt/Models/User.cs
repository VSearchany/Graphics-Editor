using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtApp.Models
{
    public class User : IdentityUser
    {
        public List<Advertisement> Advertisements { get; set; }
    }
}