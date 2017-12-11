using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealtApp.Models
{
    public class User : IdentityUser
    {
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}