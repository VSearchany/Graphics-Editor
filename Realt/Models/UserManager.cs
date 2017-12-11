using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace RealtApp.Models
{
    public class UserManager : UserManager<User>
    {
        public UserManager(IUserStore<User> userStore) : base(userStore)
        {

        }

        public static UserManager CreateManager(IdentityFactoryOptions<UserManager> options,
                                                IOwinContext context)
        {
            ApplicationContext db = context.Get<ApplicationContext>();
            UserManager manager = new UserManager(new UserStore<User>(db));

            User admin = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };
            string adminPWD = "superadmin";
            IdentityResult chkUser = manager.Create(admin, adminPWD);
            if (chkUser.Succeeded)
            {
                IdentityResult addRole;
                addRole = manager.AddToRole(admin.Id, "Admin");
                addRole = manager.AddToRole(admin.Id, "User");
            }

            return manager;
        }
    }
}