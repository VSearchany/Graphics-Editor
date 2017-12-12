using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Realt.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext() : base("IdentityDb") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }

        public DbSet<Advertisement> Advertisements { get; set; }
    }
}