using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace RealtApp.Models
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store) : base(store) { }

        public static ApplicationRoleManager CreateManager(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            ApplicationRoleManager roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<ApplicationContext>()));
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new ApplicationRole
                {
                    Name = "Admin"
                };
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("User"))
            {
                var role = new ApplicationRole
                {
                    Name = "User"
                };
                roleManager.Create(role);
            }
            return roleManager;
        }
    }
}